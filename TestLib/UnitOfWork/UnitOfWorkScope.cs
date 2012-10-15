using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingAbelNu.Utilities;
using TestLib.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TestLib.UnitOfWork
{
/// <summary>
/// Purpose of a UnitOfWorkScope.
/// </summary>
public enum UnitOfWorkScopePurpose
{
    /// <summary>
    /// This unit of work scope will only be used for reading.
    /// </summary>
    Reading,

    /// <summary>
    /// This unit of work scope will be used for writing. If SaveChanges
    /// isn't called, it cancels the entire unit of work.
    /// </summary>
    Writing
}

/// <summary>
/// Scoped unit of work, that merges with any existing scoped unit of work
/// activated by a previous function in the call chain.
/// </summary>
/// <typeparam name="TDbContext">The type of the DbContext</typeparam>
public class UnitOfWorkScope<TDbContext> : Disposable
    where TDbContext : DbContext, new()
{
    /// <summary>
    /// Handle class for holding the real DbContext and some state for it.
    /// </summary>
    private class ScopedDbContext : Disposable
    {
        /// <summary>
        /// The real DbContext.
        /// </summary>
        public TDbContext DbContext { get; private set; }

        /// <summary>
        /// Has there been a failure that should block saving?
        /// </summary>
        public bool BlockSave { get; set; }

        /// <summary>
        /// Was any unit of work scope using this DbContext opened for writing?
        /// </summary>
        public bool ForWriting { get; private set; }

        /// <summary>
        /// Switch off guard for direct calls to SaveChanges.
        /// </summary>
        public bool AllowSaving { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="forWriting">Is the root context opened for writing?</param>
        public ScopedDbContext(bool forWriting)
        {
            ForWriting = forWriting;
            DbContext = new TDbContext();
            ((IObjectContextAdapter)DbContext).ObjectContext.SavingChanges
                += GuardAgainstDirectSaves;
        }

        void GuardAgainstDirectSaves(object sender, EventArgs e)
        {
            if (!AllowSaving)
            {
                throw new InvalidOperationException(
                    "Don't call SaveChanges directly on a context owned by a UnitOfWorkScope. " +
                    "use UnitOfWorkScope.SaveChanges instead.");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    ((IObjectContextAdapter)DbContext).ObjectContext.SavingChanges
                        -= GuardAgainstDirectSaves;

                    DbContext.Dispose();
                    DbContext = null;
                }
            }
            base.Dispose(disposing);
        }
    }

    [ThreadStatic]
    private static ScopedDbContext scopedDbContext;

    private bool isRoot = false;

    private bool saveChangesCalled = false;

    /// <summary>
    /// Access the ambient DbContext that this unit of work uses.
    /// </summary>
    public TDbContext DbContext
    {
        get
        {
            return scopedDbContext.DbContext;
        }
    }

    private UnitOfWorkScopePurpose purpose;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="purpose">Will this unit of work scope be used for reading or writing?</param>
    public UnitOfWorkScope(UnitOfWorkScopePurpose purpose)
    {
        this.purpose = purpose;
        if (scopedDbContext == null)
        {
            scopedDbContext = new ScopedDbContext(purpose == UnitOfWorkScopePurpose.Writing);
            isRoot = true;
        }
        if (purpose == UnitOfWorkScopePurpose.Writing && !scopedDbContext.ForWriting)
        {
            throw new InvalidOperationException(
                "Can't open a child UnitOfWorkScope for writing when the root scope " +
                "is opened for reading.");
        }
    }

    /// <summary>
    /// Dispose implementation, checking post conditions for purpose and saving.
    /// </summary>
    /// <param name="disposing">Are we disposing?</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            // We're disposing and SaveChanges wasn't called. That usually
            // means we're exiting the scope with an exception. Block saves
            // of the entire unit of work.
            if (purpose == UnitOfWorkScopePurpose.Writing && !saveChangesCalled)
            {
                scopedDbContext.BlockSave = true;
                // Don't throw here - it would mask original exception when exiting
                // a using block.
            }

            if (scopedDbContext != null && isRoot)
            {
                scopedDbContext.Dispose();
                scopedDbContext = null;
            }
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// For child unit of work scopes: Mark for saving. For the root: Do actually save.
    /// </summary>
    public void SaveChanges()
    {
        if (purpose != UnitOfWorkScopePurpose.Writing)
        {
            throw new InvalidOperationException(
                "Can't save changes on a UnitOfWorkScope with Reading purpose.");
        }

        if (scopedDbContext.BlockSave)
        {
            throw new InvalidOperationException(
                "Saving of changes is blocked for this unit of work scope. An enclosed " +
                "scope was disposed without calling SaveChanges.");
        }

        saveChangesCalled = true;

        if (!isRoot)
        {
            return;
        }

        scopedDbContext.AllowSaving = true;
        scopedDbContext.DbContext.SaveChanges();
        scopedDbContext.AllowSaving = false;
    }
}
}
