using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPConditions.Numeric
{
    internal class UniversalNumberComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if(!IsNumber(x) || !IsNumber(y))
                throw new InvalidOperationException();

            if(x == null)
            {
                return y == null
                    ? 0
                    : -1;
            }
            else
            {
                if(y == null)
                    return 1;
            }

            return Decimal.Compare(Convert.ToDecimal(x), Convert.ToDecimal(y));
        }

        private bool IsNumber(object value)
        {
            if(value is sbyte || value is sbyte?)
                return true;
            if(value is byte || value is byte?)
                return true;
            if(value is short || value is short?)
                return true;
            if(value is ushort || value is ushort?)
                return true;
            if(value is int || value is int?)
                return true;
            if(value is uint || value is uint?)
                return true;
            if(value is long || value is long?)
                return true;
            if(value is ulong || value is ulong?)
                return true;
            if(value is float || value is float?)
                return true;
            if(value is double || value is double?)
                return true;
            if(value is decimal || value is decimal?)
                return true;
            return false;
        }
    }
}
