using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPConditions.Numeric;

namespace MPConditions
{
    public static class NumericConditionsExtensions
    {
        /// <summary>
        /// Returns an <see cref="T:MPConditions.Numeric.INumberCondition`2"/> object that can be used to start validating the current <see cref="T:System.SByte"/> <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value under test.</param>
        /// <param name="name">The name of the value under test.</param>
        /// <returns>
        /// An <see cref="T:MPConditions.Numeric.INumberCondition`2"/> object.
        /// </returns>
        [CLSCompliant(false)]
        public static INumberCondition<sbyte, sbyte> Condition(this sbyte value, string name)
        {
            return new NumberCondition<sbyte, sbyte>(value, value, name);
        }
        [CLSCompliant(false)]
        public static INullableNumberCondition<sbyte, sbyte?> Condition(this sbyte? value, string name)
        {
            return new NullableNumberCondition<sbyte, sbyte?>(value, value, name);
        }

        public static INumberCondition<byte, byte> Condition(this byte value, string name)
        {
            return new NumberCondition<byte, byte>(value, value, name);
        }
        public static INullableNumberCondition<byte, byte?> Condition(this byte? value, string name)
        {
            return new NullableNumberCondition<byte, byte?>(value, value, name);
        }


        public static INumberCondition<short, short> Condition(this short value, string name)
        {
            return new NumberCondition<short, short>(value, value, name);
        }
        public static INullableNumberCondition<short, short?> Condition(this short? value, string name)
        {
            return new NullableNumberCondition<short, short?>(value, value, name);
        }

        [CLSCompliant(false)]
        public static INumberCondition<ushort, ushort> Condition(this ushort value, string name)
        {
            return new NumberCondition<ushort, ushort>(value, value, name);
        }

        [CLSCompliant(false)]
        public static INullableNumberCondition<ushort, ushort?> Condition(this ushort? value, string name)
        {
            return new NullableNumberCondition<ushort, ushort?>(value, value, name);
        }


        public static INumberCondition<int, int> Condition(this int value, string name)
        {
            return new NumberCondition<int, int>(value, value, name);
        }
        public static INullableNumberCondition<int, int?> Condition(this int? value, string name)
        {
            return new NullableNumberCondition<int, int?>(value, value, name);
        }

        [CLSCompliant(false)]
        public static INumberCondition<uint, uint> Condition(this uint value, string name)
        {
            return new NumberCondition<uint, uint>(value, value, name);
        }
        [CLSCompliant(false)]
        public static INullableNumberCondition<uint, uint?> Condition(this uint? value, string name)
        {
            return new NullableNumberCondition<uint, uint?>(value, value, name);
        }


        public static INumberCondition<long, long> Condition(this long value, string name)
        {
            return new NumberCondition<long, long>(value, value, name);
        }
        public static INullableNumberCondition<long, long?> Condition(this long? value, string name)
        {
            return new NullableNumberCondition<long, long?>(value, value, name);
        }

        [CLSCompliant(false)]
        public static INumberCondition<ulong, ulong> Condition(this ulong value, string name)
        {
            return new NumberCondition<ulong, ulong>(value, value, name);
        }
        [CLSCompliant(false)]
        public static INullableNumberCondition<ulong, ulong?> Condition(this ulong? value, string name)
        {
            return new NullableNumberCondition<ulong, ulong?>(value, value, name);
        }


        public static INumberCondition<float, float> Condition(this float value, string name)
        {
            return new NumberCondition<float, float>(value, value, name);
        }
        public static INullableNumberCondition<float, float?> Condition(this float? value, string name)
        {
            return new NullableNumberCondition<float, float?>(value, value, name);
        }


        public static INumberCondition<double, double> Condition(this double value, string name)
        {
            return new NumberCondition<double, double>(value, value, name);
        }
        public static INullableNumberCondition<double, double?> Condition(this double? value, string name)
        {
            return new NullableNumberCondition<double, double?>(value, value, name);
        }


        public static INumberCondition<decimal, decimal> Condition(this decimal value, string name)
        {
            return new NumberCondition<decimal, decimal>(value, value, name);
        }
        public static INullableNumberCondition<decimal, decimal?> Condition(this decimal? value, string name)
        {
            return new NullableNumberCondition<decimal, decimal?>(value, value, name);
        }

    }
}
