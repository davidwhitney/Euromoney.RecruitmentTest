using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class TextAnalyserTests
    {
        [TestCase("This contains one bad word", 1)]
        [TestCase("This contains one Bad word", 1)]
        [TestCase("This contains one Bad. word", 1)]
        public void Analyse_Given_Text_With_One_Bad_Word_Returns_One(string text, int badWordsExpected)
        {
            var badWords = new List<String>() {"bad"};
            var textAnalyser = new TextAnalyser(badWords);
            var badWordsFound = textAnalyser.Analyse(text);

            Assert.AreEqual(badWordsExpected, badWordsFound);
        }

        [TestCase("This contains zero superbad words", 0)]
        public void Analyse_Given_Bad_Word_As_Substring_Of_Good_Word_Returns_Zero(string text, int badWordsExpected)
        {
            var badWords = new List<String>() { "bad" };
            var textAnalyser = new TextAnalyser(badWords);
            var badWordsFound = textAnalyser.Analyse(text);

            Assert.AreEqual(badWordsExpected, badWordsFound);
        }

        [TestCase("bad", 1)]
        [TestCase("Bad", 1)]
        public void AddBadWord_Given_Existing_Word_Does_Nothing(string badWord, int expectedBadWordsCount)
        {
            var badWords = new List<String>() { "bad" };
            var textAnalyser = new TextAnalyser(badWords);
            textAnalyser.AddBadWord(badWord);
            var badWordsCount = textAnalyser.CountBadWords();

            Assert.AreEqual(expectedBadWordsCount, badWordsCount);
        }

        [TestCase("worse", 1)]
        public void RemoveBadWord_Given_Unknown_Word_Does_Nothing(string badWord, int expectedBadWordsCount)
        {
            var badWords = new List<String>() { "bad" };
            var textAnalyser = new TextAnalyser(badWords);
            textAnalyser.RemoveBadWord(badWord);
            var badWordsCount = textAnalyser.CountBadWords();

            Assert.AreEqual(expectedBadWordsCount, badWordsCount);
        }

        [TestCase("bad", 0)]
        [TestCase("Bad", 0)]
        public void RemoveBadWord_Given_Existing_Word_Removes_It(string badWord, int expectedBadWordsCount)
        {
            var badWords = new List<String>() { "bad" };
            var textAnalyser = new TextAnalyser(badWords);
            textAnalyser.RemoveBadWord(badWord);
            var badWordsCount = textAnalyser.CountBadWords();

            Assert.AreEqual(expectedBadWordsCount, badWordsCount);
        }

        [TestCase("bad", "b#d")]
        [TestCase("Bad", "B#d")]
        [TestCase("Horrible", "H######e")]
        public void Filter_Given_Existing_Word_Returns_Filtered_Version(string badWord, string expectedFilteredBadWord)
        {
            var badWords = new List<String>() { "bad", "horrible" };
            var textAnalyser = new TextAnalyser(badWords);
            var actualFilteredBadWord = textAnalyser.Filter(badWord);

            Assert.AreEqual(expectedFilteredBadWord, actualFilteredBadWord);
        }
    }
}
