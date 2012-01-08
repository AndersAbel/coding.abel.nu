using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace TestLib
{
public class LogWriter : IDisposable
{
    private StreamWriter m_Stream;

    public LogWriter(string logFile)
    {
        m_Stream = new StreamWriter(logFile, true);
        m_Stream.WriteLine("Starting logging at {0}", DateTime.Now);
    }

    public void WriteLine(string message)
    {
        m_Stream.WriteLine(message);
    }

    #region IDisposable implementation
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private bool m_Disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!m_Disposed)
        {
            if (disposing)
            {
                m_Stream.Dispose();
            }

            m_Disposed = true;
        }
    }

    #endregion
}

public class DetailedLogWriter : LogWriter
{
    public DetailedLogWriter(string logFile)
        : base(logFile)
    {
        WriteLine(string.Format("Logging from {0}", Assembly.GetExecutingAssembly().FullName));
    }

    private bool m_Disposed = false;

    protected override void Dispose(bool disposing)
    {
        if (!m_Disposed)
        {
            WriteLine(string.Format("Logging ended on {0}", DateTime.Now));
            WriteLine(string.Empty);
            base.Dispose(disposing);
        }
    }

}
}
