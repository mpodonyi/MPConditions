using FluentAssertions;
using MPConditions.Core;
using Xunit;

namespace MPConditions.Test.UnitTests
{
    public class StringTests
    {
        [Fact]
        public void StartsWith()
        {
            {
                string foo = "Mike was here";

                foo.Condition("foo").StartsWith("Mike").Success();
            }
            {
                string foo = "Mike was here";

                foo.Condition("foo").StartsWith("Miko").Fail(ExceptionTypes.OutOfRange);
            }
            {
                string foo = null;

                foo.Condition("foo").StartsWith("Miko").Fail(ExceptionTypes.Null);
            }
            {
                string foo = "";

                foo.Condition("foo").StartsWith("Miko").Fail(ExceptionTypes.OutOfRange);
            }
        }
    }
}
