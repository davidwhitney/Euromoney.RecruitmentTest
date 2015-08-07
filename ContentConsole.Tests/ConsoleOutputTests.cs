using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ContentConsole.Tests
{
    [TestClass()]
    public class ConsoleOutputTests
    {
        [TestMethod()]
        public void ConsoleOutputTest()
        {
            
        }

        [TestMethod()]
        public void CheckWordsTest()
        {
            int expected = 2;
            string[] badWords = new string[] { "swine", "bad", "nasty", "horrible" };
            string content =
               "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            ConsoleOutput twoBad = new ConsoleOutput(badWords, content, false);
            int actual = twoBad.CheckWords();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HideBadWordsTest()
        {
            
        }

        [TestMethod()]
        public void ShowBadWordsTest()
        {
            
        }

        [TestMethod()]
        public void SpaceText()
        {
            
        }
    }
}
