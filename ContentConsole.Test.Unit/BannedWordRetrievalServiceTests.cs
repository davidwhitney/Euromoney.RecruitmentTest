using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.DataRepository;
using ContentConsole.Services;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class BannedWordRetrievalServiceTests
    {
        [Test]
        public void GetBannedWords_InitializedWithEmptyRepo_ReturnsEmptyList()
        {
            var mockRepo = new Mock<IBannedWordRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(new List<string>());

            IBannedWordRetrievalService bannedWordRetrievalService = new BannedWordRetrievalService(mockRepo.Object);

            Assert.AreSame(bannedWordRetrievalService.GetBannedWords(), mockRepo.Object.GetAll());
        }

        [Test]
        public void GetBannedWords_InitializedWithRepo_ReturnsMatchingList()
        {
            var mockRepo = new Mock<IBannedWordRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(new List<string>() { "banned", "word" });

            IBannedWordRetrievalService bannedWordRetrievalService = new BannedWordRetrievalService(mockRepo.Object);
            IEnumerable<string> serviceBannedWords = bannedWordRetrievalService.GetBannedWords();

            Assert.AreEqual(serviceBannedWords.Count(), 2);
            Assert.IsTrue(serviceBannedWords.Contains("banned"));
            Assert.IsTrue(serviceBannedWords.Contains("word"));
        }
    }
}
