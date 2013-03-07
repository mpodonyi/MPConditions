using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace MPConditions.Test
{
    /// <summary>
    /// Summary description for NumericTest
    /// </summary>
    [TestClass]
    public class NumericTest
    {
        public NumericTest()
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
        public void Int_Between_Success()
        {
            int foo = 5;

            Action act = () => foo.Condition("foo").Between(3, 6).Throw();

            act.ShouldNotThrow();
            
        }

        [TestMethod]
        public void Int_Between_Fail()
        {
            int foo = 5;

            Action act = () => foo.Condition("foo").Between(8, 12).Throw();

            act.ShouldThrow<ArgumentOutOfRangeException>()
                .WithMessage("'foo'", ComparisonMode.Substring)
                .WithMessage("'5'", ComparisonMode.Substring)
                .WithMessage("'8'", ComparisonMode.Substring)
                .WithMessage("'12'", ComparisonMode.Substring);
        }


        [TestMethod]
        public void Int_Nullable_Between_Success()
        {
            int? foo = 5;

            Action act = () => foo.Condition("foo").Between(3, 6).Throw();
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void Int_Nullable_Between_Fail()
        {
            int? foo = 5;

            Action act = () => foo.Condition("foo").Between(8, 12).Throw();

            act.ShouldThrow<ArgumentOutOfRangeException>()
                .WithMessage("'foo'", ComparisonMode.Substring)
                .WithMessage("'5'", ComparisonMode.Substring)
                .WithMessage("'8'", ComparisonMode.Substring)
                .WithMessage("'12'", ComparisonMode.Substring);


            foo = null;

            act = () => foo.Condition("foo").Between(8, 12).Throw();

            act.ShouldThrow<ArgumentOutOfRangeException>()
                .WithMessage("'foo'", ComparisonMode.Substring)
                .WithMessage("'8'", ComparisonMode.Substring)
                .WithMessage("'12'", ComparisonMode.Substring);
        }

       


     

    }
}
