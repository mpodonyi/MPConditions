using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MPConditions.Numeric
{
    public class UniversalNumberComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if(!IsNumber(x))
                throw new ArgumentException("The argument is not a numeric type.", "x");

            if(!IsNumber(y))
                throw new ArgumentException("The argument is not a numeric type.", "y");

            if(IsNull(x))
            {
                if(IsNull(y))
                    return 0;

                if(IsNaN(y))
                    throw new Exception("Can't compare with isNan");

                //Any other value is bigger
                return -1;
            }

            if(IsNull(y))
            {
                //if(IsNull(x))
                //    return 0;

                if(IsNaN(x))
                    return 1;

                //Any other value is bigger
                return 1;
            }

            if(IsNegativeInfinite(x))
            {
                if(IsNegativeInfinite(y))
                    return 0;

                if(IsNaN(y))
                    return 1;

                return -1;
            }

            if(IsNegativeInfinite(y))
            {
                if(IsNaN(x))
                    return -1;

                return 1;
            }

            if(IsPositivInfinite(x))
            {
                if(IsPositivInfinite(y))
                    return 0;

                if(IsNaN(y))
                    return 1;

                return 1;
            }

            if(IsPositivInfinite(y))
            {
                if(IsNaN(x))
                    return -1;

                return -1;
            }

            if(IsNaN(x))
            {
                if(IsNaN(y))
                    return 0;

                return -1;
            }

            if(IsNaN(y))
            {
                return 1;
            }

            //if you are here then both values are valid numbers
            var convertionTypeX = GetConvertionType(x);
            var convertionTypeY = GetConvertionType(y);

            if(convertionTypeX == convertionTypeY)
            {
                return ((IComparable)Convert.ChangeType(x, convertionTypeX, null)).CompareTo(Convert.ChangeType(y, convertionTypeY, null));
            }

            throw new NotImplementedException();

        }

        private int CompareDoubleWithDecimal(double dob, decimal dec)
        {
            return 0;
        }

        private static Type GetConvertionType(object value)
        {
            switch(Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Decimal:
                    return typeof(decimal);
                case TypeCode.Single:
                case TypeCode.Double:
                    return typeof(double);
            }

            return null;
        }


        //private static Type GetConvertionType(object x, object y)
        //{ 
        //    switch()

        //}

        //private bool IsNumber(object value)
        //{
        //    return (value == null) || (Array.IndexOf(_TypeCode, Type.GetTypeCode(value.GetType())) != -1);
        //}

        private bool IsNumberType(Type valuetype)
        {
            switch(Type.GetTypeCode(valuetype))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
            }

            return false;
        }

        private bool IsNumber(object value)
        {
            if(value == null)
                return true;

            //Type underlyingtype = Nullable.GetUnderlyingType(value.GetType());

            return //(underlyingtype != null)
                //? IsNumberType(underlyingtype)
            //    : 
                IsNumberType(value.GetType());
        }

        private bool IsType(object value, TypeCode typeCode)
        {
            return typeCode == Type.GetTypeCode(value.GetType());
        }

        private bool IsNull(object value)
        {
            return (value == null);
        }

        private bool IsNegativeInfinite(object value)
        {
            switch(Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Single:
                    return float.IsNegativeInfinity((float)value);
                case TypeCode.Double:
                    return double.IsNegativeInfinity((double)value);
            }

            return false;
        }

        private bool IsPositivInfinite(object value)
        {
            switch(Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Single:
                    return float.IsPositiveInfinity((float)value);
                case TypeCode.Double:
                    return double.IsPositiveInfinity((double)value);
            }

            return false;
        }


        private bool IsNaN(object value)
        {
            switch(Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Single:
                    return float.IsNaN((float)value);
                case TypeCode.Double:
                    return double.IsNaN((double)value);
            }

            return false;
        }
    }
}
