using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Helpers;
using ContentConsole.Services;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BannedWordCounterServiceTests
    {
        [Test]
        public void CountBannedWords_OnLowercaseContentwithUppercaseBannedWord_CountsBannedWords()
        {
            const string upperBannedWord = "BANNED";
            const string lowercaseContent = "banned content";
            var lowercaseRetrievedBannedWordsService = new Mock<IBannedWordRetrievalService>();
            lowercaseRetrievedBannedWordsService
                .Setup(service => service.GetBannedWords())
                .Returns(new List<string> { upperBannedWord });

            IBannedWordCounterService bannedWordCounterService
                = new BannedWordCounterService(lowercaseRetrievedBannedWordsService.Object, new PhraseMatcher());

            Assert.AreEqual(bannedWordCounterService.CountBannedWords(lowercaseContent), 1);
        }

        [Test]
        public void CountBannedWords_OnUppercaseContentwithLowercaseBannedWord_CountsBannedWords()
        {
            const string lowercaseBannedWord = "banned";
            const string uppercaseContent = "BANNED CONTENT";
            var lowercaseRetrievedBannedWordsService = new Mock<IBannedWordRetrievalService>();
            lowercaseRetrievedBannedWordsService
                .Setup(service => service.GetBannedWords())
                .Returns(new List<string> { lowercaseBannedWord });

            IBannedWordCounterService bannedWordCounterService
                = new BannedWordCounterService(lowercaseRetrievedBannedWordsService.Object, new PhraseMatcher());

            Assert.AreEqual(bannedWordCounterService.CountBannedWords(uppercaseContent), 1);
        }

        [Test]
        public void CountBannedWords_BannedWordAtSentenceEndNoPunctuation_CountsBannedWords()
        {
            const string lowercaseBannedWord = "banned";
            const string uppercaseContent = "This word is banned";
            var lowercaseRetrievedBannedWordsService = new Mock<IBannedWordRetrievalService>();
            lowercaseRetrievedBannedWordsService
                .Setup(service => service.GetBannedWords())
                .Returns(new List<string> { lowercaseBannedWord });

            IBannedWordCounterService bannedWordCounterService
                = new BannedWordCounterService(lowercaseRetrievedBannedWordsService.Object, new PhraseMatcher());

            Assert.AreEqual(bannedWordCounterService.CountBannedWords(uppercaseContent), 1);
        }

        [Test]
        public void CountBannedWords_BannedWordAtSentenceEndWithPunctuation_CountsBannedWords()
        {
            const string lowercaseBannedWord = "banned";
            const string uppercaseContent = "This word is banned.";
            var lowercaseRetrievedBannedWordsService = new Mock<IBannedWordRetrievalService>();
            lowercaseRetrievedBannedWordsService
                .Setup(service => service.GetBannedWords())
                .Returns(new List<string> { lowercaseBannedWord });

            IBannedWordCounterService bannedWordCounterService
                = new BannedWordCounterService(lowercaseRetrievedBannedWordsService.Object, new PhraseMatcher());

            Assert.AreEqual(bannedWordCounterService.CountBannedWords(uppercaseContent), 1);
        }

        [Test]
        public void CountBannedWords_BannedWordAtSentenceStartAndEnd_CountsBannedWords()
        {
            const string lowercaseBannedWord = "banned";
            const string uppercaseContent = "banned words are banned";
            var lowercaseRetrievedBannedWordsService = new Mock<IBannedWordRetrievalService>();
            lowercaseRetrievedBannedWordsService
                .Setup(service => service.GetBannedWords())
                .Returns(new List<string> { lowercaseBannedWord });

            IBannedWordCounterService bannedWordCounterService
                = new BannedWordCounterService(lowercaseRetrievedBannedWordsService.Object, new PhraseMatcher());

            Assert.AreEqual(bannedWordCounterService.CountBannedWords(uppercaseContent), 2);
        }

        [Test]
        public void CountBannedWords_BannedWordAtSentenceStart_CountsBannedWords()
        {
            const string lowercaseBannedWord = "banned";
            const string uppercaseContent = "banned words";
            var lowercaseRetrievedBannedWordsService = new Mock<IBannedWordRetrievalService>();
            lowercaseRetrievedBannedWordsService
                .Setup(service => service.GetBannedWords())
                .Returns(new List<string> { lowercaseBannedWord });

            IBannedWordCounterService bannedWordCounterService
                = new BannedWordCounterService(lowercaseRetrievedBannedWordsService.Object, new PhraseMatcher());

            Assert.AreEqual(bannedWordCounterService.CountBannedWords(uppercaseContent), 1);
        }
    }
}
