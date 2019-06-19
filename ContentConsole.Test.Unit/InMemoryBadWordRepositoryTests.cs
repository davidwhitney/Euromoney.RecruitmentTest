using NUnit.Framework;
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
    }
}
