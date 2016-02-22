using System.Collections.Generic;
using ContentConsole.DAL.Repositories;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class ContentParserTests
    {
        private ContentParser _unitUnderTest;
        private Mock<IContentRulesRepository> _mockContentRulesRepository;
        private string _testInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        private string _testFilteredText = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
        private readonly List<string> _testNegativeWords = new List<string>()
        {
            "bad",
            "horrible"
        };

        [SetUp]
        public void SetUp()
        {
            _mockContentRulesRepository = new Mock<IContentRulesRepository>();
            _mockContentRulesRepository.Setup(x => x.GetNegativeWords()).Returns(_testNegativeWords);
            _unitUnderTest = new ContentParser(_mockContentRulesRepository.Object);
        }

        [Test]
        public void CountNegativeWords_ValidInputIsNotFound_Returns0()
        {            
            var result = _unitUnderTest.CountNegativeWords(string.Empty);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void CountNegativeWords_ValidInputWith2NegativeWords_Returns2()
        {                   
            var result = _unitUnderTest.CountNegativeWords(_testInput);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CountNegativeWords_RetreivesNegativeWordsFromDataStore()
        {
            _unitUnderTest.CountNegativeWords(_testInput);

            _mockContentRulesRepository.Verify(x => x.GetNegativeWords());
        }

        [Test]
        [TestCase("bad", "b#d")]
        [TestCase("bad bad", "b#d b#d")]
        [TestCase("bad words in the string are horrible", "b#d words in the string are h######e")]
        public void FilterNegativeWordsIfEnabled_ReplacesAllLettersBetweenFirstAndLastWithHashes(string input, string expected)
        {
            var result = _unitUnderTest.FilterNegativeWordsIfEnabled(input, true);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("bad", "bad")]
        [TestCase("bad bad", "bad bad")]
        [TestCase("bad words in the string are horrible", "bad words in the string are horrible")]
        public void FilterNegativeWordsIfEnabled_ShouldFilterIsFalse_ReturnsOriginalInput(string input, string expected)
        {
            var result = _unitUnderTest.FilterNegativeWordsIfEnabled(input, false);

            Assert.AreEqual(result, expected);          
        }
    }
}
