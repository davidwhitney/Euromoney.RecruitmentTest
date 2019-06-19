using NUnit.Framework;
using System;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BadWordParserTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_WhenPassedNullContent_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new BadWordParser();

            // Act
            sut.Parse(null);

            // Assert
        }

        [Test]
        public void Parse_WhenPassedEmptyString_ShouldReturnParserResponse()
        {
            // Arrange
            var sut = new BadWordParser();
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
            var sut = new BadWordParser();
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
            var sut = new BadWordParser();
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
            var sut = new BadWordParser();
            var content = "This is nice content";

            // Act
            var actual = sut.Parse(content);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.BadWordCount);
        }
    }
}
