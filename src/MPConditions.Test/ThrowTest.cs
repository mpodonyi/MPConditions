using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MPConditions;
using MPConditions.DefaultExtensions;
using MPConditions.ThrowExtensions;
using System.Linq;

namespace MPConditions.Test
{
    [TestClass]
    public class ThrowTest
    {
        public ThrowTest()
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
        [TestCategory("Throw")]
        public void Throw_ThrowsArgumentNullException_Success()
        {
            string foo = null;

            Action act = () => foo.Condition("foo").NotNull().Throw();

            act.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        [TestCategory("Throw")]
        public void Throw_ThrowsArgumentNullException_Fail()
        {
            string foo = "foo";

            Action act = () => foo.Condition("foo").NotNull().Throw();

            act.ShouldNotThrow();
        }

    }
}
