using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Numeric;

namespace MPConditions
{
    public static class NumericConditionsExtensions
    {
        public static NumberCondition<sbyte> Conditionize(this sbyte value, string name)
        {
            return new NumberCondition<sbyte>(value, name);
        }
        public static NullableNumberCondition<sbyte> Conditionize(this sbyte? value, string name)
        {
            return new NullableNumberCondition<sbyte>(value, name);
        }


        public static NumberCondition<byte> Conditionize(this byte value, string name)
        {
            return new NumberCondition<byte>(value, name);
        }
        public static NullableNumberCondition<byte> Conditionize(this byte? value, string name)
        {
            return new NullableNumberCondition<byte>(value, name);
        }


        public static NumberCondition<short> Conditionize(this short value, string name)
        {
            return new NumberCondition<short>(value, name);
        }
        public static NullableNumberCondition<short> Conditionize(this short? value, string name)
        {
            return new NullableNumberCondition<short>(value, name);
        }


        public static NumberCondition<ushort> Conditionize(this ushort value, string name)
        {
            return new NumberCondition<ushort>(value, name);
        }
        public static NullableNumberCondition<ushort> Conditionize(this ushort? value, string name)
        {
            return new NullableNumberCondition<ushort>(value, name);
        }


        public static NumberCondition<int> Conditionize(this int value, string name)
        {
            return new NumberCondition<int>(value, name);
        }
        public static NullableNumberCondition<int> Conditionize(this int? value, string name)
        {
            return new NullableNumberCondition<int>(value, name);
        }


        public static NumberCondition<uint> Conditionize(this uint value, string name)
        {
            return new NumberCondition<uint>(value, name);
        }
        public static NullableNumberCondition<uint> Conditionize(this uint? value, string name)
        {
            return new NullableNumberCondition<uint>(value, name);
        }


        public static NumberCondition<long> Conditionize(this long value, string name)
        {
            return new NumberCondition<long>(value, name);
        }
        public static NullableNumberCondition<long> Conditionize(this long? value, string name)
        {
            return new NullableNumberCondition<long>(value, name);
        }


        public static NumberCondition<ulong> Conditionize(this ulong value, string name)
        {
            return new NumberCondition<ulong>(value, name);
        }
        public static NullableNumberCondition<ulong> Conditionize(this ulong? value, string name)
        {
            return new NullableNumberCondition<ulong>(value, name);
        }


        public static NumberCondition<float> Conditionize(this float value, string name)
        {
            return new NumberCondition<float>(value, name);
        }
        public static NullableNumberCondition<float> Conditionize(this float? value, string name)
        {
            return new NullableNumberCondition<float>(value, name);
        }


        public static NumberCondition<double> Conditionize(this double value, string name)
        {
            return new NumberCondition<double>(value, name);
        }
        public static NullableNumberCondition<double> Conditionize(this double? value, string name)
        {
            return new NullableNumberCondition<double>(value, name);
        }


        public static NumberCondition<decimal> Conditionize(this decimal value, string name)
        {
            return new NumberCondition<decimal>(value, name);
        }
        public static NullableNumberCondition<decimal> Conditionize(this decimal? value, string name)
        {
            return new NullableNumberCondition<decimal>(value, name);
        }

    }
}
