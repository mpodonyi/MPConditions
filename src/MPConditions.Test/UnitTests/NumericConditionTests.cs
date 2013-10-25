using Xunit;

namespace MPConditions.Test.UnitTests
{
    public class NumericConditionTests
    {

        [Fact]
        public void Is()
        {
            {
                int foo = 5;
                int bar = 5;

                foo.Cond().Is(bar).Success();
            }
            {
                int foo = 5;
                int? bar = 5;

                foo.Cond().Is(bar).Success();
            }
            {
                int? foo = 5;
                int bar = 5;

                foo.Cond().Is(bar).Success();
            }
            {
                int? foo = 5;
                int? bar = 5;

                foo.Cond().Is(bar).Success();
            }

            //---------- 
            {
                int foo = 5;
                int bar = 4;

                foo.Cond().Is(bar).Fail();
            }
            {
                int foo = 5;
                int? bar = 4;

                foo.Cond().Is(bar).Fail();
            }
            {
                int? foo = 4;
                int bar = 5;

                foo.Cond().Is(bar).Fail();
            }
            //---------- 
            {
                int foo = 5;
                int? bar = null;

                foo.Cond().Is(bar).Fail();
            }
            {
                int? foo = null;
                int bar = 5;

                foo.Cond().Is(bar).Fail();
            }
            //----------
            {
                int? foo = null;
                int? bar = null;

                foo.Cond().Is(bar).Success();
            }
        }

        [Fact]
        public void IsNot()
        {
            {
                int foo = 5;
                int bar = 5;

                foo.Cond().IsNot(bar).Fail();
            }
            {
                int foo = 5;
                int? bar = 5;

                foo.Cond().IsNot(bar).Fail();
            }
            {
                int? foo = 5;
                int bar = 5;

                foo.Cond().IsNot(bar).Fail();
            }
            {
                int? foo = 5;
                int? bar = 5;

                foo.Cond().IsNot(bar).Fail();
            }

            //---------- 
            {
                int foo = 5;
                int bar = 4;

                foo.Cond().IsNot(bar).Success();
            }
            {
                int foo = 5;
                int? bar = 4;

                foo.Cond().IsNot(bar).Success();
            }
            {
                int? foo = 4;
                int bar = 5;

                foo.Cond().IsNot(bar).Success();
            }
            //---------- 
            {
                int foo = 5;
                int? bar = null;

                foo.Cond().IsNot(bar).Success();
            }
            {
                int? foo = null;
                int bar = 5;

                foo.Cond().IsNot(bar).Success();
            }
            //----------
            {
                int? foo = null;
                int? bar = null;

                foo.Cond().IsNot(bar).Fail();
            }
        }

        [Fact]
        public void IsPositive()
        {
            {
                int foo = 5;

                foo.Cond().IsPositive().Success();
            }
            {
                int foo = -5;

                foo.Cond().IsPositive().Fail();
            }
            {
                int foo = 0;

                foo.Cond().IsPositive().Fail();
            }
            //---------
            {
                int? foo = 5;

                foo.Cond().IsPositive().Success();
            }
            {
                int? foo = -5;

                foo.Cond().IsPositive().Fail();
            }
            {
                int? foo = 0;

                foo.Cond().IsPositive().Fail();
            }
            {
                int? foo = null;

                foo.Cond().IsPositive().Fail();
            }
        }

        [Fact]
        public void IsNegative()
        {
            {
                int foo = 5;

                foo.Cond().IsNegative().Fail();
            }
            {
                int foo = -5;

                foo.Cond().IsNegative().Success();
            }
            {
                int foo = 0;

                foo.Cond().IsNegative().Fail();
            }
            //---------
            {
                int? foo = 5;

                foo.Cond().IsNegative().Fail();
            }
            {
                int? foo = -5;

                foo.Cond().IsNegative().Success();
            }
            {
                int? foo = 0;

                foo.Cond().IsNegative().Fail();
            }
            {
                int? foo = null;

                foo.Cond().IsNegative().Fail();
            }
        }

        [Fact]
        public void IsLessThan()
        {
            {
                int foo = 10;

                foo.Cond().IsLessThan(5).Fail();
            }
            {
                int foo = 5;

                foo.Cond().IsLessThan(5).Fail();
            }
            {
                int foo = 0;

                foo.Cond().IsLessThan(5).Success();
            }
            //---------
            {
                int? foo = 10;

                foo.Cond().IsLessThan(5).Fail();
            }
            {
                int? foo = 5;

                foo.Cond().IsLessThan(5).Fail();
            }
            {
                int? foo = 0;

                foo.Cond().IsLessThan(5).Success();
            }
            {
                int? foo = null;

                foo.Cond().IsLessThan(5).Fail();
            }
        }

        [Fact]
        public void IsLessOrEqualTo()
        {
            {
                int foo = 10;

                foo.Cond().IsLessOrEqualTo(5).Fail();
            }
            {
                int foo = 5;

                foo.Cond().IsLessOrEqualTo(5).Success();
            }
            {
                int foo = 0;

                foo.Cond().IsLessOrEqualTo(5).Success();
            }
            //---------
            {
                int? foo = 10;

                foo.Cond().IsLessOrEqualTo(5).Fail();
            }
            {
                int? foo = 5;

                foo.Cond().IsLessOrEqualTo(5).Success();
            }
            {
                int? foo = 0;

                foo.Cond().IsLessOrEqualTo(5).Success();
            }
            {
                int? foo = null;

                foo.Cond().IsLessOrEqualTo(5).Fail();
            }
        }

        [Fact]
        public void IsGreaterThan()
        {
            {
                int foo = 10;

                foo.Cond().IsGreaterThan(5).Success();
            }
            {
                int foo = 5;

                foo.Cond().IsGreaterThan(5).Fail();
            }
            {
                int foo = 0;

                foo.Cond().IsGreaterThan(5).Fail();
            }
            //---------
            {
                int? foo = 10;

                foo.Cond().IsGreaterThan(5).Success();
            }
            {
                int? foo = 5;

                foo.Cond().IsGreaterThan(5).Fail();
            }
            {
                int? foo = 0;

                foo.Cond().IsGreaterThan(5).Fail();
            }
            {
                int? foo = null;

                foo.Cond().IsGreaterThan(5).Fail();
            }
        }

        [Fact]
        public void IsGreaterOrEqualTo()
        {
            {
                int foo = 10;

                foo.Cond().IsGreaterOrEqualTo(5).Success();
            }
            {
                int foo = 5;

                foo.Cond().IsGreaterOrEqualTo(5).Success();
            }
            {
                int foo = 0;

                foo.Cond().IsGreaterOrEqualTo(5).Fail();
            }
            //---------
            {
                int? foo = 10;

                foo.Cond().IsGreaterOrEqualTo(5).Success();
            }
            {
                int? foo = 5;

                foo.Cond().IsGreaterOrEqualTo(5).Success();
            }
            {
                int? foo = 0;

                foo.Cond().IsGreaterOrEqualTo(5).Fail();
            }
            {
                int? foo = null;

                foo.Cond().IsGreaterOrEqualTo(5).Fail();
            }
        }

        [Fact]
        public void IsInRange()
        {
            {
                int foo = 10;

                foo.Cond().IsInRange(4, 6).Fail();
            }
            {
                int foo = 5;

                foo.Cond().IsInRange(4, 6).Success();
            }
            {
                int foo = 4;

                foo.Cond().IsInRange(4, 6).Success();
            }
            {
                int foo = 0;

                foo.Cond().IsInRange(4, 6).Fail();
            }
            //---------
            {
                int? foo = 10;

                foo.Cond().IsInRange(4, 6).Fail();
            }
            {
                int? foo = 5;

                foo.Cond().IsInRange(4, 6).Success();
            }
            {
                int? foo = 4;

                foo.Cond().IsInRange(4, 6).Success();
            }
            {
                int? foo = 0;

                foo.Cond().IsInRange(4, 6).Fail();
            }
            {
                int? foo = null;

                foo.Cond().IsInRange(4, 6).Fail();
            }
        }

        [Fact]
        public void IsOneOf()
        {
            {
                int foo = 10;

                foo.Cond().IsOneOf(null).Throws();
            }
            {
                int foo = 10;

                foo.Cond().IsOneOf(4, 6).Fail();
            }
            {
                int foo = 10;

                foo.Cond().IsOneOf(4, 10, 6).Success();
            }
            //--------------
            {
                int? foo = 10;

                foo.Cond().IsOneOf(null).Throws();
            }
            {
                int? foo = 10;

                foo.Cond().IsOneOf(4, 6).Fail();
            }
            {
                int? foo = 10;

                foo.Cond().IsOneOf(4, 10, 6).Success();
            }
            //--------------
            {
                int? foo = null;

                foo.Cond().IsOneOf(null).Throws();
            }
            {
                int? foo = null;

                foo.Cond().IsOneOf(4, 6).Fail();
            }
        }

    }
}
