using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.DataRepository;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BannedWordFileRepositoryTests
    {
        [Test]
        public void Initialize_GivenFileThatDoesNotExist_ThrowsFileNotFoundException()
        {
            Assert.Throws(typeof(ArgumentException),
                delegate { throw new ArgumentException(); });
            Assert.Throws<FileNotFoundException>(() => new BannedWordFileRepository("NotABannedWordFile.txt"));
        }

        [Test]
        public void Initialize_GivenFileThatExists_DoesNotThrowException()
        {
            IBannedWordRepository repository = new BannedWordFileRepository("../../BannedWordFile.txt");
        }

        [Test]
        public void Initialize_GivenFileThatExists_ReadsFileWords()
        {
            IBannedWordRepository repository = new BannedWordFileRepository("../../BannedWordFile.txt");

            Assert.IsTrue(repository.Contains("b1"));
            Assert.IsTrue(repository.Contains("b2"));
            Assert.IsTrue(repository.Contains("b3"));
            Assert.IsTrue(repository.Contains("B3"));

            Assert.AreEqual(repository.GetAll().Count(), 3);
        }
    }
}
