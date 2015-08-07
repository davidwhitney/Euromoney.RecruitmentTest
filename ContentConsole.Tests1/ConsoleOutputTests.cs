using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole;
using NUnit.Framework;
namespace ContentConsole.Tests
{
    [TestFixture()]
    public class ConsoleOutputTests
    {
        int expected;
        string[] badWords;
        string content;
        ConsoleOutput twoBad;
        [SetUp]
        public void initailise()
        {
            badWords = new string[] { "swine", "bad", "nasty", "horrible" };
            content =
               "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            twoBad = new ConsoleOutput(badWords, content, false);
        }

        [Test(), ExpectedException(typeof(ArgumentException))]
        public void ConsoleOutputTest()
        {
            throw new ArgumentException();
        }

        [Test()]
        public void CheckWordsTest()
        {
            expected = 2;
            int actual = twoBad.CheckWords();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void HideBadWordsTest()
        {
            
        }

        [Test()]
        public void ShowBadWordsTest()
        {
            
        }

        [Test()]
        public void SpaceText()
        {
            
        }
        [TearDown]
        public void CleanUp()
        {
            twoBad = null;
        }
    }
}
