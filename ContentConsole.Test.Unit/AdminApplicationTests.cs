using ContentConsole.ApplicationTypes;
using ContentConsole.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Test.Unit
{
    class AdminApplicationTests
    {
        private Mock<IApiClientService> apiClientService;
        private BannedWordDictionary wordDictionary;
        private Mock<IUserInputHandler> inputHandler;
        private AdminApplication adminApplication;
        List<string> bannedWords = new List<string>();

        [SetUp]
        public void Setup()
        {
            apiClientService = new Mock<IApiClientService>();
            wordDictionary = new BannedWordDictionary();
            inputHandler = new Mock<IUserInputHandler>();
            adminApplication = new AdminApplication(apiClientService.Object, wordDictionary, inputHandler.Object);
        }

        [Test]
        public void ShouldAddWordsOk()
        {
            apiClientService.Setup(e => e.GetContent()).Returns("");

            inputHandler.SetupSequence(e => e.InputLine())
                 .Returns("add")
                 .Returns("newword");

            inputHandler.SetupSequence(e => e.YesNoHandling())
                .Returns("y")
                .Returns("n")
                .Returns("n");

            inputHandler.Setup(e => e.ReadKey()).Returns("");

            adminApplication.RunCustomApplication();

            bannedWords = wordDictionary.GetBannedWords();

            Assert.AreEqual(5, bannedWords.Count);
            Assert.AreEqual("newword", bannedWords[4]);
        }

        [Test]
        public void ShouldDeleteWordsOk()
        {
            apiClientService.Setup(e => e.GetContent()).Returns("");

            inputHandler.SetupSequence(e => e.InputLine())
                 .Returns("del")
                 .Returns("swine");

            inputHandler.SetupSequence(e => e.YesNoHandling())
                .Returns("y")
                .Returns("n")
                .Returns("n");

            inputHandler.Setup(e => e.ReadKey()).Returns("");

            adminApplication.RunCustomApplication();

            bannedWords = wordDictionary.GetBannedWords();

            Assert.AreEqual(3, bannedWords.Count);
        }
    }
}
