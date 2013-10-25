using System;
using MPConditions.Primitives;

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
        public static NumberCondition<sbyte, sbyte> Cond(this sbyte value, string name = null)
        {
            return new NumberCondition<sbyte, sbyte>(value, name);
        }
        [CLSCompliant(false)]
        public static NullableNumberCondition<sbyte, sbyte?> Cond(this sbyte? value, string name = null)
        {
            return new NullableNumberCondition<sbyte, sbyte?>(value, name);
        }

        public static NumberCondition<byte, byte> Cond(this byte value, string name = null)
        {
            return new NumberCondition<byte, byte>(value, name);
        }
        public static NullableNumberCondition<byte, byte?> Cond(this byte? value, string name = null)
        {
            return new NullableNumberCondition<byte, byte?>(value, name);
        }


        public static NumberCondition<short, short> Cond(this short value, string name = null)
        {
            return new NumberCondition<short, short>(value, name);
        }
        public static NullableNumberCondition<short, short?> Cond(this short? value, string name = null)
        {
            return new NullableNumberCondition<short, short?>(value, name);
        }

        [CLSCompliant(false)]
        public static NumberCondition<ushort, ushort> Cond(this ushort value, string name = null)
        {
            return new NumberCondition<ushort, ushort>(value, name);
        }

        [CLSCompliant(false)]
        public static NullableNumberCondition<ushort, ushort?> Cond(this ushort? value, string name = null)
        {
            return new NullableNumberCondition<ushort, ushort?>(value, name);
        }


        public static NumberCondition<int, int> Cond(this int value, string name = null)
        {
            return new NumberCondition<int, int>(value, name);
        }
        public static NullableNumberCondition<int, int?> Cond(this int? value, string name = null)
        {
            return new NullableNumberCondition<int, int?>(value, name);
        }

        [CLSCompliant(false)]
        public static NumberCondition<uint, uint> Cond(this uint value, string name = null)
        {
            return new NumberCondition<uint, uint>(value, name);
        }
        [CLSCompliant(false)]
        public static NullableNumberCondition<uint, uint?> Cond(this uint? value, string name = null)
        {
            return new NullableNumberCondition<uint, uint?>(value, name);
        }


        public static NumberCondition<long, long> Cond(this long value, string name = null)
        {
            return new NumberCondition<long, long>(value, name);
        }
        public static NullableNumberCondition<long, long?> Cond(this long? value, string name = null)
        {
            return new NullableNumberCondition<long, long?>(value, name);
        }

        [CLSCompliant(false)]
        public static NumberCondition<ulong, ulong> Cond(this ulong value, string name = null)
        {
            return new NumberCondition<ulong, ulong>(value, name);
        }
        [CLSCompliant(false)]
        public static NullableNumberCondition<ulong, ulong?> Cond(this ulong? value, string name = null)
        {
            return new NullableNumberCondition<ulong, ulong?>(value, name);
        }


        public static NumberCondition<float, float> Cond(this float value, string name = null)
        {
            return new NumberCondition<float, float>(value, name);
        }
        public static NullableNumberCondition<float, float?> Cond(this float? value, string name = null)
        {
            return new NullableNumberCondition<float, float?>(value, name);
        }


        public static NumberCondition<double, double> Cond(this double value, string name = null)
        {
            return new NumberCondition<double, double>(value, name);
        }
        public static NullableNumberCondition<double, double?> Cond(this double? value, string name = null)
        {
            return new NullableNumberCondition<double, double?>(value, name);
        }


        public static NumberCondition<decimal, decimal> Cond(this decimal value, string name = null)
        {
            return new NumberCondition<decimal, decimal>(value, name);
        }
        public static NullableNumberCondition<decimal, decimal?> Cond(this decimal? value, string name = null)
        {
            return new NullableNumberCondition<decimal, decimal?>(value, name);
        }

    }
}
