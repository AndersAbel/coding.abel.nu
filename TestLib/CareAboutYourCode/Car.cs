using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestLib.CareAboutYourCode
{
    public class DragStrip { public bool AtEnd { get; set; } }
}

namespace TestLib.CareAboutYourCode.Sample1
{
    public class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "reg")]
        public string regNo { get; set; }
        public string Brand { get; set; }

        /// <summary>
        /// Drive the car
        /// </summary>
        /// <param name="speed">Speed to drive at</param>
        public void Drive()
        {
            Debug.WriteLine("Driving car!");
        }




        public void DragRace(DragStrip strip)
        {
            while (!strip.AtEnd)
            {
                try
                {
                    Drive();
                }
                catch (Exception) { }
            }
        }
    }
}

namespace TestLib.CareAboutYourCode.Sample2
{
    /// <summary>
    /// Car class.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// RegNo
        /// </summary>
        public string RegNo { get; set; }

        /// <summary>
        /// Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Drive the car
        /// </summary>
        public void Drive()
        {
            // Write driving car message.
            Debug.WriteLine("Driving car!");
        }

        /// <summary>
        /// Drive the car
        /// </summary>
        /// <param name="strip">Dragstrip</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void DragRace(DragStrip strip)
        {
            // Continue to drive until at end.
            while (!strip.AtEnd)
            {
                try
                {
                    Drive();
                }
                catch (Exception) { }
            }
        }
    }
}

namespace TestLib.CareAboutYourCode.Sample3
{
/// <summary>
/// A car.
/// </summary>
public class Car
{
    /// <summary>
    /// The registration number of the car. Is unique to each care. This
    /// field should never be null.
    /// </summary>
    public string RegNo { get; set; }

    /// <summary>
    /// The brand of the car, if available. Set to null if unknown.
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Drive the car normally.
    /// </summary>
    public void Drive()
    {
        Debug.WriteLine("Driving car!");
    }

    /// <summary>
    /// Drag race with the car, ignoring any problems during the race - focus on winning.
    /// </summary>
    /// <param name="strip">The dragstrip that the race is run on.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
    public void DragRace(DragStrip strip)
    {
        while (!strip.AtEnd)
        {
            try
            {
                Drive();
            }
            catch (Exception)
            {
                // Silently ignore any exceptions during racing. Just focus on winning.
                // The car will need a major service after the race anyways.
            }
        }
    }
}
}