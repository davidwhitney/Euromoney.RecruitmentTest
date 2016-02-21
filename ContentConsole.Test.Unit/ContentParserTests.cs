using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class ContentParserTests
    {
        private ContentParser _unitUnderTest;
        private Mock<IContentRules> _mockContentRules;

        [SetUp]
        public void SetUp()
        {
            var testNegativeWords = new List<string>()
            {
                "bad",
                "horrible"
            };

            _mockContentRules = new Mock<IContentRules>();
            _mockContentRules.Setup(x => x.NegativeWords).Returns(testNegativeWords);
            _unitUnderTest = new ContentParser(_mockContentRules.Object);
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
            var testInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";   

            var result = _unitUnderTest.CountNegativeWords(testInput);

            Assert.AreEqual(2, result);
        }
    }
}
