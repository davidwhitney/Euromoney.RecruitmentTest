using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BadWordServiceTests
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
        public void GetBadWordCount_WhenPassedNullContent_ShouldThrowArgumentNullException()
        {
            // Arrange

            var sut = new BadWordService(MockBadWordRepo.Object);

            // Act
            sut.GetBadWordCount(null);

            // Assert
        }

        [Test]
        public void GetBadWordCount_WhenPassedEmptyString_ShouldReturnZero()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = string.Empty;

            // Act
            var actual = sut.GetBadWordCount(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void Parse_WhenPassedContentWithABadWord_ShouldReturnCorrectBadWordCount()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = "This is horrible content";

            // Act
            var actual = sut.GetBadWordCount(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GetBadWordCount_WhenPassedContentWithZeroBadWords_ShouldReturnZero()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = "This is nice content";

            // Act
            var actual = sut.GetBadWordCount(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void GetBadWordCount_WhenPassedContentWithBadWordsInDifferentCasing_ShouldReturnDetectBadWord()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = "This is HORRIBLE content";

            // Act
            var actual = sut.GetBadWordCount(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GetBadWordCount_WhenPassedContentWithTheSameBadWordTwice_ShouldCountBothInstancesOfBadWord()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = "This is horrible horrible content";

            // Act
            var actual = sut.GetBadWordCount(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFilteredContent_WhenPassedNullContent_ShouldThrowArgumentNullException()
        {
            // Arrange

            var sut = new BadWordService(MockBadWordRepo.Object);

            // Act
            sut.GetFilteredContent(null);

            // Assert
        }

        [Test]
        public void GetFilteredContent_WhenPassedContentWithTheBadWord_ShouldReturnFilteredContent()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = "This is horrible content";
            var expected = "This is h######e content";

            // Act
            var actual = sut.GetFilteredContent(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFilteredContent_WhenPassedContentWithTheNoBadWords_ShouldReturnOriginalContent()
        {
            // Arrange
            var sut = new BadWordService(MockBadWordRepo.Object);
            var content = "This is nice content";


            // Act
            var actual = sut.GetFilteredContent(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(content, actual);
        }
    }
}
