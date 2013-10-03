using FluentAssertions;

using Xunit;


namespace MPConditions.Test
{
    /// <summary>
    /// Summary description for NumericTest
    /// </summary>
    public class NumericTest
    {
        public NumericTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [Fact]
        public void Int_Between_Success()
        {
            int foo = 5;

            foo.Condition("foo").Between(3, 6).GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        [Fact]
        public void Int_Between_Fail()
        {
            int foo = 5;

            var result = foo.Condition("foo").Between(8, 12).GetResult();

            result.Should().NotBeNull();
            result.ExceptionType.Should().Be(ExceptionTypes.OutOfRange);
        }


        [Fact]
        public void Int_Nullable_Between_Success()
        {
            int? foo = 5;

            foo.Condition("foo").Between(3, 6).GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        [Fact]
        public void Int_Nullable_Between_Fail()
        {
            int? foo = 5;

            var result = foo.Condition("foo").Between(8, 12).GetResult();

            result.Should().NotBeNull();
            result.ExceptionType.Should().Be(ExceptionTypes.OutOfRange);

            foo = null;

            result = foo.Condition("foo").Between(8, 12).GetResult();

            result.Should().NotBeNull();
            result.ExceptionType.Should().Be(ExceptionTypes.Null);
        }






    }
}
