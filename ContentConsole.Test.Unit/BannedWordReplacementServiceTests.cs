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
    public class BannedWordReplacementServiceTests
    {

        private IBannedWordRetrievalService CreatedMockBannedWordRetrievalService()
        {
            var mockRetrievalService = new Mock<IBannedWordRetrievalService>();
            mockRetrievalService.Setup(service => service.GetBannedWords())
                .Returns(new List<string> { "a", "an", "banned", "WORD", "bad" });
            return mockRetrievalService.Object;
        }

        [Test]
        public void ReplaceBannedWords_OnGivenNullContent_ReturnsNull()
        {
            IBannedWordReplacementService replacementService =
                new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            Assert.IsNull(replacementService.ReplaceBannedWords(null));
        }

        [Test]
        public void ReplaceBannedWords_OnGivenEmptyContent_ReturnsEmptyString()
        {
            IBannedWordReplacementService replacementService =
                 new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            Assert.AreEqual("", replacementService.ReplaceBannedWords(""));
        }

        [Test]
        public void ReplaceBannedWords_OnGivenEmptyPaddedContent_ReturnsEmptyOriginalPaddedInput()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "\t\n  ";
            Assert.AreEqual(testContent, replacementService.ReplaceBannedWords(testContent), testContent);
        }

        [Test]
        public void ReplaceBannedWords_OnGivenBannedWordContentLower_ReplacesBannedWordsWithOriginalCapitalization()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "lower case banned word ";
            const string expectedReplacement = "lower case b####d w##d ";
            Assert.AreEqual(expectedReplacement, replacementService.ReplaceBannedWords(testContent));
        }

        [Test]
        public void ReplaceBannedWords_OnGivenBannedWordContentUpper_ReplacesBannedWordsWithOriginalCapitalization()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "UPPER CASE BANNED WORD ";
            const string expectedReplacement = "UPPER CASE B####D W##D ";
            Assert.AreEqual(expectedReplacement, replacementService.ReplaceBannedWords(testContent));
        }

        [Test]
        public void ReplaceBannedWords_OnGivenSingleLetterBannedWord_HidesEntireBannedWord()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "a lower case banned word ";
            const string expectedReplacement = "# lower case b####d w##d ";
            Assert.AreEqual(expectedReplacement, replacementService.ReplaceBannedWords(testContent));
        }

        [Test]
        public void ReplaceBannedWords_OnGivenTwoLetterBannedWord_HidesEntireBannedWord()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "AN UPPER CASE BANNED WORD ";
            const string expectedReplacement = "## UPPER CASE B####D W##D ";
            Assert.AreEqual(expectedReplacement, replacementService.ReplaceBannedWords(testContent));
        }

        [Test]
        public void ReplaceBannedWords_OnGivenThreeLetterBannedWord_HidesMiddleLetterOfBannedWord()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "The weather in Manchester in winter is bad.It rains all the time -it must be horrible for people visiting.";
            const string expectedReplacement = "The weather in Manchester in winter is b#d.It rains all the time -it must be horrible for people visiting.";
            Assert.AreEqual(expectedReplacement, replacementService.ReplaceBannedWords(testContent));
        }

        // We might want to check for this, but for now don't check for pluralization and skip the word.
        [Test]
        public void ReplaceBannedWords_OnGivenBadWordPluralized_DoesNotReplacePluralizedBannedWord()
        {
            IBannedWordReplacementService replacementService =
               new BannedWordReplacementService(CreatedMockBannedWordRetrievalService(), new PhraseMatcher());
            const string testContent = "UPPER CASE BANNED WORDS ";
            const string expectedReplacement = "UPPER CASE B####D WORDS ";
            Assert.AreEqual(expectedReplacement, replacementService.ReplaceBannedWords(testContent));
        }
    }
}
