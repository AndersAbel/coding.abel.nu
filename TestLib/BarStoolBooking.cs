using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib
{
    public class BarStoolBooking
    {
        static int nextBookingNumber = 1;

        public int BookingNumber { get; private set; }
        public string Name { get; set; }
        public int BarStoolNumber { get; set; }
        public DateTime Date { get; set; }

        public BarStoolBooking Submit()
        {
            BookingNumber = nextBookingNumber++;
            return this;
        }

        public static IEnumerable<BarStoolBooking> SubmitSeries(BarStoolBooking bookingInfo,
            DateTime firstDate, DateTime lastDate)
        {
            for (DateTime date = firstDate; date <= lastDate; date = date.AddDays(1))
            {
                bookingInfo.Date = date;
                yield return bookingInfo.Submit();
            }
        }
    }
}
