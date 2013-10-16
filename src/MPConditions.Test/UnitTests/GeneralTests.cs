using FluentAssertions;
using Xunit;



namespace MPConditions.Test.UnitTests
{
    public class GeneralTests
    {
        [Fact]
        public void Pass_Success()
        {
            int foo = 5;

            bool result = foo.Condition().IsInRange(3, 6).Pass();
            result.Should().BeTrue();

            string bar = "5";

            bool result2 = bar.Condition().AsNumber<int>().IsInRange(3, 6).Pass();
            result2.Should().BeTrue();
        }

        [Fact]
        public void Log_Success()
        {
            int foo = 5;

            foo.Condition().IsInRange(3, 6).Log();
        }


        [Fact]
        public void ThrowReturnsElement_Success()
        {
            int foo = 5;

            int result = foo.Condition().IsInRange(3, 6).Throw();
            result.Should().Be(5);
        }
    }
}
