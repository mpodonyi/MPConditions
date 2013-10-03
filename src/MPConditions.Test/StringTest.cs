using FluentAssertions;

using Xunit;

namespace MPConditions.Test
{
    /// <summary>
    /// Summary description for NumericTest
    /// </summary>

    public class StringTest
    {
        public StringTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [Fact]
        public void String_AsNumber_Success()
        {
            string foo = "5";

            foo.Condition("foo").AsNumber<int>().Between(3, 6).GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        [Fact]
        public void String_AsNumber_Fail()
        {
            string foo = "xxx";

            var result = foo.Condition("foo").AsNumber<int>().Between(3, 6).GetResult();

            result.Should().NotBeNull();
            result.ExceptionType.Should().Be(ExceptionTypes.WrongType);

            string foo2 = "7";

            var result2 = foo2.Condition("foo").AsNumber<int>().Between(3, 6).GetResult();

            result2.Should().NotBeNull();
            result2.ExceptionType.Should().Be(ExceptionTypes.OutOfRange);
        }

        [Fact]
        public void String_AsNullableNumber_Success()
        {
            string foo = "5";

            foo.Condition("foo").AsNullableNumber<int>().GetResult().ExceptionType.Should().Be(ExceptionTypes.None);

            foo = null;

            foo.Condition("foo").AsNullableNumber<int>().GetResult().ExceptionType.Should().Be(ExceptionTypes.None);

            foo = string.Empty;

            foo.Condition("foo").AsNullableNumber<int>().GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        [Fact]
        public void String_AsNullableNumber_Fail()
        {
            string foo = "bar";

            foo.Condition("foo").AsNullableNumber<int>().GetResult().ExceptionType.Should().Be(ExceptionTypes.WrongType);

            foo = string.Empty;

            foo.Condition("foo").AsNullableNumber<int>(false).GetResult().ExceptionType.Should().Be(ExceptionTypes.WrongType);
        }

        [Fact]
        public void String_StartsWith_Success()
        {
            string foo = "Mike was here";

            foo.Condition("foo").StartsWith("Mike").GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        [Fact]
        public void String_StartsWith_Fail()
        {
            string foo = "Mike was here";

            foo.Condition("foo").StartsWith("Mikee").GetResult().ExceptionType.Should().Be(ExceptionTypes.OutOfRange);
        }

        [Fact]
        public void Atworks()
        {
            string foo = "55";

            var sss = foo.Condition("foo").StartsWith("6").Or.AsNumber<int>().Between(56, 58).GetResult();


            //     .ExceptionType.Should().NotBe(ExceptionTypes.None);
        }










    }
}
