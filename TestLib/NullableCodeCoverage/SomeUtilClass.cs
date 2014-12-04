using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.NullableCodeCoverage
{
    using MyNumericType = System.Nullable<IntStruct>;

    public struct IntStruct
    {
        public IntStruct(int value)
        {
            Value = value;
        }

        public readonly int Value;

        public static bool operator <(IntStruct v1, IntStruct v2)
        {
            return v1.Value < v2.Value;
        }

        public static bool operator >(IntStruct v1, IntStruct v2)
        {
            return v1.Value > v2.Value;
        }
    }

    public class SomeUtilClass1
    {
        public static string IsTooLate(DateTime? value)
        {
            if (value < DateTime.Now)
            {
                return "No!";
            }

            return "Yes :-(";
        }

        public static string IsSingleDigit(int? value)
        {
            if (value < 10)
            {
                return "Yes!";
            }

            return "No!";
        }

        static readonly IntStruct SingleDigitLimit = new IntStruct(10);

        public static string IsSingleDigit(MyNumericType value)
        {
            if (value < SingleDigitLimit)
            {
                return "Yes!";
            }

            return "No!";
        }

        public class IntClass
        {
            public IntClass(int value)
            {
                Value = value;
            }

            public readonly int Value;

            public static bool operator <(IntClass v1, IntClass v2)
            {
                return v1.Value < v2.Value;
            }

            public static bool operator >(IntClass v1, IntClass v2)
            {
                return v1.Value > v2.Value;
            }
        }

        public static string IsSingleDigit(IntClass value)
        {
            if (value < new IntClass(10))
            {
                return "Yes!";
            }

            return "No!";
        }
    }

    public class SomeUtilClass2
    {
        public static string IsTooLate(DateTime? value)
        {
            if (value.Value < DateTime.Now)
            {
                return "No!";
            }

            return "Yes :-(";
        }

        public struct IntStruct
        {
            public IntStruct(int value)
            {
                Value = value;
            }

            public readonly int Value;

            public static bool operator <(IntStruct v1, IntStruct v2)
            {
                return v1.Value < v2.Value;
            }

            public static bool operator >(IntStruct v1, IntStruct v2)
            {
                return v1.Value > v2.Value;
            }
        }

        public static string IsSingleDigit(IntStruct? value)
        {
            if (value.Value < new IntStruct(10))
            {
                return "Yes!";
            }

            return "No!";
        }
    }
}
