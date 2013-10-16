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

                foo.Condition().Is(bar).Success();
            }
            {
                int foo = 5;
                int? bar = 5;

                foo.Condition().Is(bar).Success();
            }
            {
                int? foo = 5;
                int bar = 5;

                foo.Condition().Is(bar).Success();
            }
            {
                int? foo = 5;
                int? bar = 5;

                foo.Condition().Is(bar).Success();
            }

            //---------- 
            {
                int foo = 5;
                int bar = 4;

                foo.Condition().Is(bar).Fail();
            }
            {
                int foo = 5;
                int? bar = 4;

                foo.Condition().Is(bar).Fail();
            }
            {
                int? foo = 4;
                int bar = 5;

                foo.Condition().Is(bar).Fail();
            }
            //---------- 
            {
                int foo = 5;
                int? bar = null;

                foo.Condition().Is(bar).Fail();
            }
            {
                int? foo = null;
                int bar = 5;

                foo.Condition().Is(bar).Fail();
            }
            //----------
            {
                int? foo = null;
                int? bar = null;

                foo.Condition().Is(bar).Success();
            }
        }

        [Fact]
        public void IsNot()
        {
            {
                int foo = 5;
                int bar = 5;

                foo.Condition().IsNot(bar).Fail();
            }
            {
                int foo = 5;
                int? bar = 5;

                foo.Condition().IsNot(bar).Fail();
            }
            {
                int? foo = 5;
                int bar = 5;

                foo.Condition().IsNot(bar).Fail();
            }
            {
                int? foo = 5;
                int? bar = 5;

                foo.Condition().IsNot(bar).Fail();
            }

            //---------- 
            {
                int foo = 5;
                int bar = 4;

                foo.Condition().IsNot(bar).Success();
            }
            {
                int foo = 5;
                int? bar = 4;

                foo.Condition().IsNot(bar).Success();
            }
            {
                int? foo = 4;
                int bar = 5;

                foo.Condition().IsNot(bar).Success();
            }
            //---------- 
            {
                int foo = 5;
                int? bar = null;

                foo.Condition().IsNot(bar).Success();
            }
            {
                int? foo = null;
                int bar = 5;

                foo.Condition().IsNot(bar).Success();
            }
            //----------
            {
                int? foo = null;
                int? bar = null;

                foo.Condition().IsNot(bar).Fail();
            }
        }

        [Fact]
        public void IsPositive()
        {
            {
                int foo = 5;

                foo.Condition().IsPositive().Success();
            }
            {
                int foo = -5;

                foo.Condition().IsPositive().Fail();
            }
            {
                int foo = 0;

                foo.Condition().IsPositive().Fail();
            }
            //---------
            {
                int? foo = 5;

                foo.Condition().IsPositive().Success();
            }
            {
                int? foo = -5;

                foo.Condition().IsPositive().Fail();
            }
            {
                int? foo = 0;

                foo.Condition().IsPositive().Fail();
            }
            {
                int? foo = null;

                foo.Condition().IsPositive().Fail();
            }
        }

        [Fact]
        public void IsNegative()
        {
            {
                int foo = 5;

                foo.Condition().IsNegative().Fail();
            }
            {
                int foo = -5;

                foo.Condition().IsNegative().Success();
            }
            {
                int foo = 0;

                foo.Condition().IsNegative().Fail();
            }
            //---------
            {
                int? foo = 5;

                foo.Condition().IsNegative().Fail();
            }
            {
                int? foo = -5;

                foo.Condition().IsNegative().Success();
            }
            {
                int? foo = 0;

                foo.Condition().IsNegative().Fail();
            }
            {
                int? foo = null;

                foo.Condition().IsNegative().Fail();
            }
        }

        [Fact]
        public void IsLessThan()
        {
            {
                int foo = 10;

                foo.Condition().IsLessThan(5).Fail();
            }
            {
                int foo = 5;

                foo.Condition().IsLessThan(5).Fail();
            }
            {
                int foo = 0;

                foo.Condition().IsLessThan(5).Success();
            }
            //---------
            {
                int? foo = 10;

                foo.Condition().IsLessThan(5).Fail();
            }
            {
                int? foo = 5;

                foo.Condition().IsLessThan(5).Fail();
            }
            {
                int? foo = 0;

                foo.Condition().IsLessThan(5).Success();
            }
            {
                int? foo = null;

                foo.Condition().IsLessThan(5).Fail();
            }
        }

        [Fact]
        public void IsLessOrEqualTo()
        {
            {
                int foo = 10;

                foo.Condition().IsLessOrEqualTo(5).Fail();
            }
            {
                int foo = 5;

                foo.Condition().IsLessOrEqualTo(5).Success();
            }
            {
                int foo = 0;

                foo.Condition().IsLessOrEqualTo(5).Success();
            }
            //---------
            {
                int? foo = 10;

                foo.Condition().IsLessOrEqualTo(5).Fail();
            }
            {
                int? foo = 5;

                foo.Condition().IsLessOrEqualTo(5).Success();
            }
            {
                int? foo = 0;

                foo.Condition().IsLessOrEqualTo(5).Success();
            }
            {
                int? foo = null;

                foo.Condition().IsLessOrEqualTo(5).Fail();
            }
        }

        [Fact]
        public void IsGreaterThan()
        {
            {
                int foo = 10;

                foo.Condition().IsGreaterThan(5).Success();
            }
            {
                int foo = 5;

                foo.Condition().IsGreaterThan(5).Fail();
            }
            {
                int foo = 0;

                foo.Condition().IsGreaterThan(5).Fail();
            }
            //---------
            {
                int? foo = 10;

                foo.Condition().IsGreaterThan(5).Success();
            }
            {
                int? foo = 5;

                foo.Condition().IsGreaterThan(5).Fail();
            }
            {
                int? foo = 0;

                foo.Condition().IsGreaterThan(5).Fail();
            }
            {
                int? foo = null;

                foo.Condition().IsGreaterThan(5).Fail();
            }
        }

        [Fact]
        public void IsGreaterOrEqualTo()
        {
            {
                int foo = 10;

                foo.Condition().IsGreaterOrEqualTo(5).Success();
            }
            {
                int foo = 5;

                foo.Condition().IsGreaterOrEqualTo(5).Success();
            }
            {
                int foo = 0;

                foo.Condition().IsGreaterOrEqualTo(5).Fail();
            }
            //---------
            {
                int? foo = 10;

                foo.Condition().IsGreaterOrEqualTo(5).Success();
            }
            {
                int? foo = 5;

                foo.Condition().IsGreaterOrEqualTo(5).Success();
            }
            {
                int? foo = 0;

                foo.Condition().IsGreaterOrEqualTo(5).Fail();
            }
            {
                int? foo = null;

                foo.Condition().IsGreaterOrEqualTo(5).Fail();
            }
        }

        [Fact]
        public void IsInRange()
        {
            {
                int foo = 10;

                foo.Condition().IsInRange(4, 6).Fail();
            }
            {
                int foo = 5;

                foo.Condition().IsInRange(4, 6).Success();
            }
            {
                int foo = 4;

                foo.Condition().IsInRange(4, 6).Success();
            }
            {
                int foo = 0;

                foo.Condition().IsInRange(4, 6).Fail();
            }
            //---------
            {
                int? foo = 10;

                foo.Condition().IsInRange(4, 6).Fail();
            }
            {
                int? foo = 5;

                foo.Condition().IsInRange(4, 6).Success();
            }
            {
                int? foo = 4;

                foo.Condition().IsInRange(4, 6).Success();
            }
            {
                int? foo = 0;

                foo.Condition().IsInRange(4, 6).Fail();
            }
            {
                int? foo = null;

                foo.Condition().IsInRange(4, 6).Fail();
            }
        }

        [Fact]
        public void IsOneOf()
        {
            {
                int foo = 10;

                foo.Condition().IsOneOf(null).Throws();
            }
            {
                int foo = 10;

                foo.Condition().IsOneOf(4, 6).Fail();
            }
            {
                int foo = 10;

                foo.Condition().IsOneOf(4, 10, 6).Success();
            }
            //--------------
            {
                int? foo = 10;

                foo.Condition().IsOneOf(null).Throws();
            }
            {
                int? foo = 10;

                foo.Condition().IsOneOf(4, 6).Fail();
            }
            {
                int? foo = 10;

                foo.Condition().IsOneOf(4, 10, 6).Success();
            }
            //--------------
            {
                int? foo = null;

                foo.Condition().IsOneOf(null).Throws();
            }
            {
                int? foo = null;

                foo.Condition().IsOneOf(4, 6).Fail();
            }
        }

    }
}
