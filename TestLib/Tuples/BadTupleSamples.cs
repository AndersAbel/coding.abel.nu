using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.Tuples
{
    public class BadTupleSamples
    {
        /// <summary>
        /// Recommended pressure of front and back tires of the car.
        /// </summary>
        public Tuple<double, double> TirePressure
        { get { return Tuple.Create(2.0, 2.4); } }

        /// <summary>
        /// Distance since last three refuels.
        /// </summary>
        public Tuple<int, int, int> KmSinceRefueling
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Calculate the average of numbers in a sequence of sequences.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double AggregatedAverage(IEnumerable<IEnumerable<int>> values)
        {
            var firstLevel = values.Select(s => Tuple.Create(s.Average(), s.Count()));

            return firstLevel.Select(fl => fl.Item1 * fl.Item2).Sum() / firstLevel.Sum(fl => fl.Item2);
        }
    }
}
