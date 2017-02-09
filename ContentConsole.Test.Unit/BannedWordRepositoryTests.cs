using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.DataRepository;
using NUnit.Framework;
namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BannedWordRepositoryTests
    {
        [Test]
        public void GetAll_OnInitialization_ReturnsEmptyNonNullEnumerable()
        {
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();
            IEnumerable<string> bannedWords = bannedWordRepository.GetAll();

            Assert.IsNotNull(bannedWords);
            Assert.AreEqual(bannedWords.Count(), 0);
        }

        [Test]
        public void Add_OnInitialization_AddsNewWordToRepository()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();

            bannedWordRepository.Add(bannedWord);

            IEnumerable<string> bannedWords = bannedWordRepository.GetAll();
            Assert.IsNotNull(bannedWords);
            Assert.AreEqual(bannedWords.Count(), 1);
            Assert.AreEqual(bannedWords.First(), bannedWord);
        }

        [Test]
        public void Add_OnAddingNull_DoesNotAddNewWord()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();

            // Add null
            bannedWordRepository.Add(null);
            bannedWordRepository.Add(bannedWord);

            IEnumerable<string> bannedWords = bannedWordRepository.GetAll();
            Assert.IsNotNull(bannedWords);
            Assert.AreEqual(bannedWords.Count(), 1);
            Assert.AreEqual(bannedWords.First(), bannedWord);
        }

        [Test]
        public void Add_OnAddingEmpty_DoesNotAddNewWord()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();

            // Add null
            bannedWordRepository.Add("");
            bannedWordRepository.Add(bannedWord);

            IEnumerable<string> bannedWords = bannedWordRepository.GetAll();
            Assert.IsNotNull(bannedWords);
            Assert.AreEqual(bannedWords.Count(), 1);
            Assert.AreEqual(bannedWords.First(), bannedWord);
        }

        [Test]
        public void Add_OnAddingDuplicateWordWithPaddedWhiteSpace_DoesNotAddDuplicate()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();

            // Add duplicate word with padding 
            bannedWordRepository.Add(bannedWord);
            bannedWordRepository.Add(" \t" + bannedWord + "\n");

            IEnumerable<string> bannedWords = bannedWordRepository.GetAll();
            Assert.IsNotNull(bannedWords);
            Assert.AreEqual(bannedWords.Count(), 1);
            Assert.AreEqual(bannedWords.First(), bannedWord);
        }

        [Test]
        public void Contains_OnInitialization_ReturnsFalse()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();
            Assert.IsFalse(bannedWordRepository.Contains(bannedWord));
        }

        [Test]
        public void Contains_OnGivenNull_ReturnsFalse()
        {
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();
            Assert.IsFalse(bannedWordRepository.Contains(null));
        }

        [Test]
        public void Contains_OnGivenEmptyWord_ReturnsFalse()
        {
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();
            Assert.IsFalse(bannedWordRepository.Contains(""));
        }

        [Test]
        public void Contains_AddingLowercaseWordAndCheckingUppercaseContains_ReturnsTrueOnMatch()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();

            bannedWordRepository.Add(bannedWord);
            Assert.IsTrue(bannedWordRepository.Contains(bannedWord));
        }

        [Test]
        public void Contains_ContainsIgnoresWhiteSpace_DoesNotAddDuplicate()
        {
            string bannedWord = "banned";
            IBannedWordRepository bannedWordRepository = new BannedWordRepository();

            // Add original word with padding 
            bannedWordRepository.Add(" \t" + bannedWord + "\n");

            // check original word is contained, as well as padded variations
            Assert.IsTrue(bannedWordRepository.Contains(bannedWord));
            Assert.IsTrue(bannedWordRepository.Contains(" " + bannedWord));
            Assert.IsTrue(bannedWordRepository.Contains("\t" + bannedWord + "\n"));
        }
    }
}
