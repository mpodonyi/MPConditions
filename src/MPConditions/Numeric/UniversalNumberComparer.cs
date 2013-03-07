using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MPConditions.Numeric
{
    internal class UniversalNumberComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if(!IsNumber(x) )
                throw new ArgumentException("The argument is not a numeric type or null.", "x");

            if(!IsNumber(y))
                throw new ArgumentException("The argument is not a numeric type or null.", "y");

            return x == null
               ? (y == null ? 0 : -1)
               : (y == null ? 1 : Decimal.Compare(Convert.ToDecimal(x), Convert.ToDecimal(y)));
        }

        private static readonly TypeCode[] _TypeCode ={TypeCode.Byte,
                                                TypeCode.Decimal,
                                                TypeCode.Double,
                                                TypeCode.Int16,
                                                TypeCode.Int32,
                                                TypeCode.Int64,
                                                TypeCode.SByte,
                                                TypeCode.Single,
                                                TypeCode.UInt16,
                                                TypeCode.UInt32,
                                                TypeCode.UInt64};

        private bool IsNumber(object value)
        {
            return (value == null) || (Array.IndexOf(_TypeCode, Type.GetTypeCode(value.GetType())) != -1);
        }
    }
}
