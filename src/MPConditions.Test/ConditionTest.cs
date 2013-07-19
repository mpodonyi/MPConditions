using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using MPConditions;
using MPConditions.DefaultExtensions;
using MPConditions.ThrowExtensions;
using Xunit;


namespace MPConditions.Test
{
    /// <summary>
    /// Summary description for NumericTest
    /// </summary>
     
    public class ConditionTest
    {
        public ConditionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


         [Fact]
        public void Pass_Success()
        {
            int foo = 5;

            bool result = foo.Condition("foo").Between(3, 6).Pass();
            result.Should().BeTrue();

            string bar = "5";

            bool result2 = bar.Condition("bar").AsNumber<int>().Between(3, 6).Pass();
            result2.Should().BeTrue();
        }

         [Fact]
         public void Pass_Fail()
        {
            int foo = 2;

            bool result = foo.Condition("foo").Between(3, 6).Pass();

            result.Should().BeFalse();
        }



        //[TestMethod]
        //[TestCategory("Condition")]
        //public void ThrowOrGet_Success()
        //{
        //    int foo = 5;

        //    int result = foo.Condition("foo").Between(3, 6).ThrowOrGet();
        //    result.Should().Be(5);

        //    string bar = "5";

        //    string result2 = bar.Condition("bar").AsNumber<int>().Between(3, 6).ThrowOrGet();
        //    result2.Should().Be("5");
        //}

        //[TestMethod]
        //[TestCategory("Condition")]
        //public void ThrowOrGet_Fail()
        //{
        //    int foo = 2;

        //    Action act = () => { int result = foo.Condition("foo").Between(3, 6).ThrowOrGet(); };

        //    act.ShouldThrow<Exception>();
        //}
    }
}
