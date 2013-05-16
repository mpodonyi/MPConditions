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
        public static NumberCondition<sbyte, sbyte> Condition(this sbyte value, string name)
        {
            return new NumberCondition<sbyte, sbyte>(value, name);
        }
        [CLSCompliant(false)]
        public static NullableNumberCondition<sbyte, sbyte?> Condition(this sbyte? value, string name)
        {
            return new NullableNumberCondition<sbyte, sbyte?>(value, name);
        }

        public static NumberCondition<byte, byte> Condition(this byte value, string name)
        {
            return new NumberCondition<byte, byte>(value, name);
        }
        public static NullableNumberCondition<byte, byte?> Condition(this byte? value, string name)
        {
            return new NullableNumberCondition<byte, byte?>(value, name);
        }


        public static NumberCondition<short, short> Condition(this short value, string name)
        {
            return new NumberCondition<short, short>(value, name);
        }
        public static NullableNumberCondition<short, short?> Condition(this short? value, string name)
        {
            return new NullableNumberCondition<short, short?>(value, name);
        }

        [CLSCompliant(false)]
        public static NumberCondition<ushort, ushort> Condition(this ushort value, string name)
        {
            return new NumberCondition<ushort, ushort>(value, name);
        }

        [CLSCompliant(false)]
        public static NullableNumberCondition<ushort, ushort?> Condition(this ushort? value, string name)
        {
            return new NullableNumberCondition<ushort, ushort?>(value, name);
        }


        public static NumberCondition<int, int> Condition(this int value, string name)
        {
            return new NumberCondition<int, int>(value, name);
        }
        public static NullableNumberCondition<int, int?> Condition(this int? value, string name)
        {
            return new NullableNumberCondition<int, int?>(value, name);
        }

        [CLSCompliant(false)]
        public static NumberCondition<uint, uint> Condition(this uint value, string name)
        {
            return new NumberCondition<uint, uint>(value, name);
        }
        [CLSCompliant(false)]
        public static NullableNumberCondition<uint, uint?> Condition(this uint? value, string name)
        {
            return new NullableNumberCondition<uint, uint?>(value, name);
        }


        public static NumberCondition<long, long> Condition(this long value, string name)
        {
            return new NumberCondition<long, long>(value, name);
        }
        public static NullableNumberCondition<long, long?> Condition(this long? value, string name)
        {
            return new NullableNumberCondition<long, long?>(value, name);
        }

        [CLSCompliant(false)]
        public static NumberCondition<ulong, ulong> Condition(this ulong value, string name)
        {
            return new NumberCondition<ulong, ulong>(value, name);
        }
        [CLSCompliant(false)]
        public static NullableNumberCondition<ulong, ulong?> Condition(this ulong? value, string name)
        {
            return new NullableNumberCondition<ulong, ulong?>(value, name);
        }


        public static NumberCondition<float, float> Condition(this float value, string name)
        {
            return new NumberCondition<float, float>(value, name);
        }
        public static NullableNumberCondition<float, float?> Condition(this float? value, string name)
        {
            return new NullableNumberCondition<float, float?>(value, name);
        }


        public static NumberCondition<double, double> Condition(this double value, string name)
        {
            return new NumberCondition<double, double>(value, name);
        }
        public static NullableNumberCondition<double, double?> Condition(this double? value, string name)
        {
            return new NullableNumberCondition<double, double?>(value, name);
        }


        public static NumberCondition<decimal, decimal> Condition(this decimal value, string name)
        {
            return new NumberCondition<decimal, decimal>(value, name);
        }
        public static NullableNumberCondition<decimal, decimal?> Condition(this decimal? value, string name)
        {
            return new NullableNumberCondition<decimal, decimal?>(value, name);
        }

    }
}
