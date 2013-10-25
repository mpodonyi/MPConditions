using Xunit;

namespace MPConditions.Test.UnitTests
{
    public class NullableNumericConditionTests
    {

        [Fact]
        public void HasValue()
        {
            {
                int? foo = 5;

                foo.Cond().HasValue().Success();
            }
            {
                int? foo = null;

                foo.Cond().HasValue().Fail();
            }
        }

        [Fact]
        public void HasNoValue()
        {
            {
                int? foo = 5;

                foo.Cond().HasNoValue().Fail();
            }
            {
                int? foo = null;

                foo.Cond().HasNoValue().Success();
            }


            {
                int? foo = null;

                foo.Cond().HasNoValue().Or.IsInRange(5, 6).Success();
            }
        }

    }
}
