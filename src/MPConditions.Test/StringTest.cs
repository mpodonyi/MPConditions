﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MPConditions.Common;
using System.Linq;

namespace MPConditions.Test
{
    /// <summary>
    /// Summary description for NumericTest
    /// </summary>
    [TestClass]
    public class StringTest
    {
        public StringTest()
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
        public void String_AsNumber_Success()
        {
            string foo = "5";

            string dfgh = foo.Condition("foo").AsNumber<int>().Between(3, 6).ThrowOrGet();

            foo.Condition("foo").AsNumber<int>().Between(3, 6).GetResult().ExceptionType.Should().Be(ExceptionTypes.None);
        }

        [TestMethod]
        public void String_AsNumber_Fail()
        {
            string foo = "xxx";

            var result = foo.Condition("foo").AsNumber<int>().Or.Between(3, 6).GetResult();

            result.Should().NotBeNull();
            result.ExceptionType.Should().Be(ExceptionTypes.WrongType);
        }

        

        

       


     

    }
}
