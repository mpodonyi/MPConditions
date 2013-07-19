using System;
using MPConditions.Numeric;
using FluentAssertions;
using Xunit;

namespace MPConditions.Test
{
    
    public class UniversalNumberComparerTest
    {
        private const int LeftLessThanRight = -1;
        private const int LeftEqualsRight = 0;
        private const int LeftGreaterThanRight = 1;

        private const byte      Byte    =1;
        private const sbyte     SByte   =1;
        private const short     Int16   =1;
        private const ushort    UInt16  =1;
        private const int       Int32   =1;
        private const uint      UInt32  =1;
        private const long      Int64   =1;
        private const ulong     UInt64  =1;
        private const decimal   Decimal =1.0M;
        private const float     Single  =1.0F;
        private const double    Double  =1.0;

        private const double DoubleNaN = double.NaN;
        private const double DoubleInfinitePos = double.PositiveInfinity;
        private const double DoubleInfiniteNeg = double.NegativeInfinity;

        private const object Null= null;

        [Fact]
        public void ByteCompare()
        {
            var unc = new UniversalNumberComparer();

            //weird
            unc.Compare(Byte, Null).Should().Be(LeftGreaterThanRight);
            unc.Compare(Byte, DoubleNaN).Should().Be(LeftGreaterThanRight);
            unc.Compare(Byte, DoubleInfinitePos).Should().Be(LeftLessThanRight);
            unc.Compare(Byte, DoubleInfiniteNeg).Should().Be(LeftGreaterThanRight);

            unc.Compare(Null, Byte).Should().Be(LeftLessThanRight);
            unc.Compare(DoubleNaN, Byte).Should().Be(LeftLessThanRight);
            unc.Compare(DoubleInfinitePos, Byte).Should().Be(LeftGreaterThanRight);
            unc.Compare(DoubleInfiniteNeg, Byte).Should().Be(LeftLessThanRight);

            //same

            unc.Compare(Byte, Byte).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, SByte).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, Int16).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, UInt16).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, Int32).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, UInt32).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, Int64).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, UInt64).Should().Be(LeftEqualsRight);
            unc.Compare(Byte, Decimal).Should().Be(LeftEqualsRight);
            //unc.Compare(Byte, Single).Should().Be(LeftEqualsRight);
            //unc.Compare(Byte, Double).Should().Be(LeftEqualsRight);

            uint? y = 1;

            unc.Compare(Byte, y).Should().Be(LeftEqualsRight);

        }

        [Fact]
        public void ByteCompare2()
        {
            double d;

            long l=long.MaxValue;
            d = (double)l;
            long l2=(long)d;
            l.CompareTo(l2).Should().Be(0);

            ulong ul = ulong.MaxValue;
            d = (double)ul;
            ulong ul2 = (ulong)d;
            ul.CompareTo(ul2).Should().Be(0);

            //float f=float.MaxValue;
            //d=Convert.ToDecimal(f);
            //float f2=(float)d;
            //f.CompareTo(f2).Should().Be(0);

            //double de= double.MaxValue;
            //d=(decimal)de;
            //double de2 = (double)d;
            //de.CompareTo(de2).Should().Be(0);

        }


        [Fact]
        public void ByteCompare3()
        {
            double? i=null;
            double i2 = double.NaN;

            object o=i;
            ((IComparable<double>)o).CompareTo(i2);

        }
    }
}
