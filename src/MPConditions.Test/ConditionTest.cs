using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MPConditions.Common;

namespace MPConditions.Test
{
    /// <summary>
    /// Summary description for NumericTest
    /// </summary>
    [TestClass]
    public class ConditionTest
    {
        public ConditionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [TestCategory("Condition")]
        public void Pass_Success()
        {
            int foo = 5;

            bool result = foo.Condition("foo").Between(3, 6).Pass();
            result.Should().BeTrue();

            string bar = "5";

            bool result2 = bar.Condition("bar").AsNumber<int>().Between(3, 6).Pass();
            result2.Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("Condition")]
        public void Pass_Fail()
        {
            int foo = 2;

            bool result = foo.Condition("foo").Between(3, 6).Pass();

            result.Should().BeFalse();
        }



        [TestMethod]
        [TestCategory("Condition")]
        public void ThrowOrGet_Success()
        {
            int foo = 5;

            int result = foo.Condition("foo").Between(3, 6).ThrowOrGet();
            result.Should().Be(5);

            string bar = "5";

            string result2 = bar.Condition("bar").AsNumber<int>().Between(3, 6).ThrowOrGet();
            result2.Should().Be("5");
        }

        [TestMethod]
        [TestCategory("Condition")]
        public void ThrowOrGet_Fail()
        {
            int foo = 2;

            Action act = () => { int result = foo.Condition("foo").Between(3, 6).ThrowOrGet(); };

            act.ShouldThrow<Exception>();
        }
    }
}
