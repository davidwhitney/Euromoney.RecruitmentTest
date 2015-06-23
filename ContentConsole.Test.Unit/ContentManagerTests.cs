using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class ContentManagerTests
    {
        [Category("Story 1")]
        [TestCase("text", 0)]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]
        public void ScanText_Test(string text, int numberOfNegativeWords)
        {
            var ta = new TextAnalyser(new List<string>() {"swine", "bad", "nasty", "horrible"});
            var cm = new ContentManager(ta, text);

            string expected = String.Format("Scanned the text:{0}{1}{0}Total Number of negative words: {2}",
                Environment.NewLine, text, numberOfNegativeWords);
            string returned = cm.ScanText();

            Assert.AreEqual(expected, returned);
        }

        [Category("Story 2")]
        [TestCase("text people", 0, 1)]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2, 3)]
        public void ScanText_Test(string text, int originalNumberOfNegativeWords, int newNumberOfNegativeWords)
        {
            var ta = new TextAnalyser(new List<string>() { "swine", "bad", "nasty", "horrible" });
            var cm = new ContentManager(ta, text);

            string expected = String.Format("Scanned the text:{0}{1}{0}Total Number of negative words: {2}",
                Environment.NewLine, text, originalNumberOfNegativeWords);
            string returned = cm.ScanText();
            Assert.AreEqual(expected, returned);

            //administrator doesn't like people and adds the word to the negative list
            cm.TextAnalyser.AddBadWord("people");

            expected = String.Format("Scanned the text:{0}{1}{0}Total Number of negative words: {2}",
                Environment.NewLine, text, newNumberOfNegativeWords);
            returned = cm.ScanText();
            Assert.AreEqual(expected, returned);
        }

        [Category("Story 3")]
        [TestCase("Horrible", "H######e")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.",
                  "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.")]
        public void ReadText_Returns_Filtered_Text(string text, string expectedFilteredText)
        {
            var ta = new TextAnalyser(new List<string>() { "swine", "bad", "nasty", "horrible" });
            var cm = new ContentManager(ta, text);

            string actualFilteredText = cm.ReadText();
            Assert.AreEqual(expectedFilteredText, actualFilteredText);
        }

        [Category("Story 4")]
        [TestCase("Horrible", "Horrible")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.",
                  "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.")]
        public void ReadText_Returns_Unfiltered_Text_When_Parameter_Is_Passed(string text, string expectedFilteredText)
        {
            var ta = new TextAnalyser(new List<string>() { "swine", "bad", "nasty", "horrible" });
            var cm = new ContentManager(ta, text);

            string actualFilteredText = cm.ReadText(filter:false);
            Assert.AreEqual(expectedFilteredText, actualFilteredText);
        }
    }


}
