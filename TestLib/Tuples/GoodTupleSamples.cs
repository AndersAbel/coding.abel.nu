using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.Tuples
{
    public class GoodTupleSamples
    {
        public struct TirePressureInfo
        {
            readonly double front, back;

            public TirePressureInfo(double front, double back)
            {
                this.front = front;
                this.back = back;
            }
            public double PressureFront { get { return front; } }
            public double PressuerBack { get { return back; } }
        }

        public TirePressureInfo TirePressuer
        { get { return new TirePressureInfo(2.0, 2.4); } }

        public IEnumerable<int> KmSinceRefueling
        { get { return null; } }

        public static double AggregatedAverage(IEnumerable<IEnumerable<int>> values)
        {
            var firstLevel = values.Select(s => new
            {
                Average = s.Average(),
                Count = s.Count()
            });

            return firstLevel.Select(fl => fl.Average * fl.Count).Sum() / firstLevel.Sum(fl => fl.Count);
        }
    }
}
