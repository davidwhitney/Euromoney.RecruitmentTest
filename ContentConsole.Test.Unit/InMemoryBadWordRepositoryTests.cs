using NUnit.Framework;
using System;
using System.Linq;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class InMemoryBadWordRepositoryTests
    {
        [Test]
        public void GetAll_ShouldReturnAllBadWords()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();

            // Act
            var actual = sut.GetAll();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Contains("swine"));
            Assert.IsTrue(actual.Contains("bad"));
            Assert.IsTrue(actual.Contains("nasty"));
            Assert.IsTrue(actual.Contains("horrible"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_WhenAddingANullString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();

            // Act
            sut.Add(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_WhenAddingANullString_ShouldThrowArgumentException()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();

            // Act
            sut.Add(string.Empty);
        }

        [Test]
        public void Add_WhenAddingABadWord_ShouldAddTheWord()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();
            var newBadWord = "naughty";

            // Act
            sut.Add(newBadWord);

            // Assert
            var badWords = sut.GetAll();
            Assert.IsTrue(badWords.Contains(newBadWord));
        }

        [Test]
        public void Add_WhenAddingAnExistingBadWord_ShouldNotCreateDuplicate()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();
            var newBadWord = "horrible";

            // Act
            sut.Add(newBadWord);

            // Assert
            var badWords = sut.GetAll();
            Assert.IsTrue(badWords.Count(x => x == newBadWord) == 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_WhenRemovingANullString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();

            // Act
            sut.Remove(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_WhenRemovingANullString_ShouldThrowArgumentException()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();

            // Act
            sut.Remove(string.Empty);
        }

        [Test]
        public void Add_WhenRemovingABadWord_ShouldRemoveTheWord()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();
            var badWord = "horrible";

            // Act
            sut.Remove(badWord);

            // Assert
            var badWords = sut.GetAll();
            Assert.IsFalse(badWords.Contains(badWord));
        }

        [Test]
        public void Add_WhenRemovingANonExistingBadWord_ShouldContinue()
        {
            // Arrange
            var sut = new InMemoryBadWordRepository();
            var badWord = "adwadwad";

            // Act
            sut.Remove(badWord);

            // Assert
        }
    }
}
