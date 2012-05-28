using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;
using System.Diagnostics;

namespace TestLibTests
{
    [TestClass]
    public class BarStoolBookingTest
    {
        private static void PrintHeader(BarStoolBooking booking)
        {
            Debug.WriteLine("{0} is booked for {1} (ref no {2}) the following dates:",
                booking.BarStoolNumber, booking.Name, booking.BookingNumber);
        }

        private static void PrintFooter(BarStoolBooking booking)
        {
            Debug.WriteLine("End of dates (ref no {0})", booking.BookingNumber);
        }

        [TestMethod]
        public void TestSeriesBooking()
        {
            BarStoolBooking baseBooking = new BarStoolBooking()
            {
                Name = "Arthur Dent",
                BarStoolNumber = 42
            };

var bookings = BarStoolBooking.SubmitSeries(baseBooking,
    DateTime.Now.Date, DateTime.Now.Date.AddDays(1));

PrintHeader(bookings.First());

foreach (var b in bookings)
{
    Debug.WriteLine(b.Date.ToShortDateString());
}

PrintFooter(bookings.First());
        }
    }
}
