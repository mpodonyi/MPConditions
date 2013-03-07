using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            foo.Condition("foo").Between(3, 6).Throw();



            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void Int_Between_Fail()
        {
            int i = 5;



            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void Int_Nullable_Between_Success()
        {
            //
            // TODO: Add test logic here
            //
        }


        //public static void Main()
        //{
        //    int uuu = 8;

        //    uuu.Conditionize("uuu").Between(2, 7).Or.Greater(6).Throw();


        //    int? uu2 = 8;

        //    uu2.Conditionize("uuu").Between(2, 7).Or.Greater(6).Throw();

        //    decimal start = 6;
        //    decimal end = 12;

        //    int? uu3 = 8;

        //    uu3.Conditionize("uuu").Between(start, end).Throw();

        //}

    }
}
