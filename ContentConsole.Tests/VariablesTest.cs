using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ContentConsoleTests
{
    
    
    /// <summary>
    ///This is a test class for VariablesTest and is intended
    ///to contain all VariablesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VariablesTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetContent
        ///</summary>
        [TestMethod()]
        public void GetContentTest()
        {
            Variables.SetContent("This is setting new bad content");
            Variables.choice = 2;

            string expected = "This is setting new bad content"; // string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Variables.GetContent();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetList
        ///</summary>
        [TestMethod()]
        public void GetListTest()
        {
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = Variables.GetList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetContent
        ///</summary>
        [TestMethod()]
        public void SetContentTest()
        {
            string content = string.Empty; // TODO: Initialize to an appropriate value
            Variables.SetContent(content);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetList
        ///</summary>
        [TestMethod()]
        public void SetListTest()
        {
            List<string> new_list = null; // TODO: Initialize to an appropriate value
            Variables.SetList(new_list);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetContent
        ///</summary>
        [TestMethod()]
        public void GetContentTest1()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Variables.GetContent();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetList
        ///</summary>
        [TestMethod()]
        public void GetListTest1()
        {
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = Variables.GetList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetContent
        ///</summary>
        [TestMethod()]
        public void SetContentTest1()
        {
            string content = string.Empty; // TODO: Initialize to an appropriate value
            Variables.SetContent(content);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetList
        ///</summary>
        [TestMethod()]
        public void SetListTest1()
        {
            List<string> new_list = null; // TODO: Initialize to an appropriate value
            Variables.SetList(new_list);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
