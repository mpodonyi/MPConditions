using Xunit;

namespace MPConditions.Test.UnitTests
{
    public class NullableNumericTests
    {

        [Fact]
        public void HasValue()
        {
            {
                int? foo = 5;

                foo.Condition().HasValue().Success();
            }
            {
                int? foo = null;

                foo.Condition().HasValue().Fail();
            }
        }

        [Fact]
        public void HasNoValue()
        {
            {
                int? foo = 5;

                foo.Condition().HasNoValue().Fail();
            }
            {
                int? foo = null;

                foo.Condition().HasNoValue().Success();
            }


            {
                int? foo = null;

                foo.Condition().HasNoValue().Or.IsInRange(5, 6).Success();
            }
        }

    }
}
