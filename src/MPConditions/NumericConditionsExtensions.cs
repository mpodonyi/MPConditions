using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Numeric;

namespace MPConditions
{
    public static class NumericConditionsExtensions
    {
        public static NumberCondition<sbyte> Condition(this sbyte value, string name)
        {
            return new NumberCondition<sbyte>(value, name);
        }
        public static NullableNumberCondition<sbyte> Condition(this sbyte? value, string name)
        {
            return new NullableNumberCondition<sbyte>(value, name);
        }


        public static NumberCondition<byte> Condition(this byte value, string name)
        {
            return new NumberCondition<byte>(value, name);
        }
        public static NullableNumberCondition<byte> Condition(this byte? value, string name)
        {
            return new NullableNumberCondition<byte>(value, name);
        }


        public static NumberCondition<short> Condition(this short value, string name)
        {
            return new NumberCondition<short>(value, name);
        }
        public static NullableNumberCondition<short> Condition(this short? value, string name)
        {
            return new NullableNumberCondition<short>(value, name);
        }


        public static NumberCondition<ushort> Condition(this ushort value, string name)
        {
            return new NumberCondition<ushort>(value, name);
        }
        public static NullableNumberCondition<ushort> Condition(this ushort? value, string name)
        {
            return new NullableNumberCondition<ushort>(value, name);
        }


        public static NumberCondition<int> Condition(this int value, string name)
        {
            return new NumberCondition<int>(value, name);
        }
        public static NullableNumberCondition<int> Condition(this int? value, string name)
        {
            return new NullableNumberCondition<int>(value, name);
        }


        public static NumberCondition<uint> Condition(this uint value, string name)
        {
            return new NumberCondition<uint>(value, name);
        }
        public static NullableNumberCondition<uint> Condition(this uint? value, string name)
        {
            return new NullableNumberCondition<uint>(value, name);
        }


        public static NumberCondition<long> Condition(this long value, string name)
        {
            return new NumberCondition<long>(value, name);
        }
        public static NullableNumberCondition<long> Condition(this long? value, string name)
        {
            return new NullableNumberCondition<long>(value, name);
        }


        public static NumberCondition<ulong> Condition(this ulong value, string name)
        {
            return new NumberCondition<ulong>(value, name);
        }
        public static NullableNumberCondition<ulong> Condition(this ulong? value, string name)
        {
            return new NullableNumberCondition<ulong>(value, name);
        }


        public static NumberCondition<float> Condition(this float value, string name)
        {
            return new NumberCondition<float>(value, name);
        }
        public static NullableNumberCondition<float> Condition(this float? value, string name)
        {
            return new NullableNumberCondition<float>(value, name);
        }


        public static NumberCondition<double> Condition(this double value, string name)
        {
            return new NumberCondition<double>(value, name);
        }
        public static NullableNumberCondition<double> Condition(this double? value, string name)
        {
            return new NullableNumberCondition<double>(value, name);
        }


        public static NumberCondition<decimal> Condition(this decimal value, string name)
        {
            return new NumberCondition<decimal>(value, name);
        }
        public static NullableNumberCondition<decimal> Condition(this decimal? value, string name)
        {
            return new NullableNumberCondition<decimal>(value, name);
        }

    }
}
