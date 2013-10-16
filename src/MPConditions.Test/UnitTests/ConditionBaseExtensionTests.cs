using FluentAssertions;
using Xunit;
using MPConditions;


namespace MPConditions.Test.UnitTests
{
    public class ConditionBaseExtensionTests
    {
        [Fact]
        public void Pass()
        {
            {
                int foo = 5;

                foo.Condition().IsInRange(3, 6).Pass().Should().BeTrue();
            }
            {
                int foo = 5;

                foo.Condition().IsInRange(6, 10).Pass().Should().BeFalse();
            }
        }
       
    }
}
