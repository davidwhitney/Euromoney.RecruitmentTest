using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BadWordParserTests
    {
        private readonly IEnumerable<string> badWords = new List<string>()
        {
            "bad",
            "horrible"
        };

        private Mock<IBadWordRepository> MockBadWordRepo
        {
            get
            {
                var mock = new Mock<IBadWordRepository>();
                mock.Setup(x => x.GetAll()).Returns(badWords);
                return mock;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_WhenPassedNullContent_ShouldThrowArgumentNullException()
        {
            // Arrange

            var sut = new BadWordParser(MockBadWordRepo.Object);

            // Act
            sut.Parse(null);

            // Assert
        }

        [Test]
        public void Parse_WhenPassedEmptyString_ShouldReturnParserResponse()
        {
            // Arrange
            var sut = new BadWordParser(MockBadWordRepo.Object);
            var content = string.Empty;

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(content, actual.Content);
            Assert.AreEqual(0, actual.BadWordCount);
        }

        [Test]
        public void Parse_WhenPassedContent_ShouldReturnParserResponseWithMatchingContent()
        {
            // Arrange
            var sut = new BadWordParser(MockBadWordRepo.Object);
            var content = "This is content";

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(content, actual.Content);
        }

        [Test]
        public void Parse_WhenPassedContentWithABadWord_ShouldReturnParserResponseWithCorrectBadWordCount()
        {
            // Arrange
            var sut = new BadWordParser(MockBadWordRepo.Object);
            var content = "This is horrible content";

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.BadWordCount);
        }

        [Test]
        public void Parse_WhenPassedContentWithZeroBadWords_ShouldReturnParserResponseWithCorrectBadWordCount()
        {
            // Arrange
            var sut = new BadWordParser(MockBadWordRepo.Object);
            var content = "This is nice content";

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.BadWordCount);
        }

        [Test]
        public void Parse_WhenPassedContentWithBadWordsInDifferentCasing_ShouldReturnDetectBadWord()
        {
            // Arrange
            var sut = new BadWordParser(MockBadWordRepo.Object);
            var content = "This is HORRIBLE content";

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.BadWordCount);
        }

        [Test]
        public void Parse_WhenPassedContentWithTheSameBadWordTwice_ShouldCountBothInstancesOfBadWord()
        {
            // Arrange
            var sut = new BadWordParser(MockBadWordRepo.Object);
            var content = "This is horrible horrible content";

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.BadWordCount);
        }
    }
}
