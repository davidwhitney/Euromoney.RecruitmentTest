using ContentConsole.ApplicationTypes;
using ContentConsole.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Test.Unit
{
    class ReaderApplicationTests
    {
        private Mock<IApiClientService> apiClientService;
        private Mock<IBannedWordDictionary> wordDictionary;
        private Mock<IUserInputHandler> inputHandler;
        private ReaderApplication readerApplication;

        [SetUp]
        public void Setup()
        {
            apiClientService = new Mock<IApiClientService>();
            wordDictionary = new Mock<IBannedWordDictionary>();
            inputHandler = new Mock<IUserInputHandler>();
            readerApplication = new ReaderApplication(apiClientService.Object, wordDictionary.Object, inputHandler.Object);
        }

        [Test]
        public void ShouldCensorText()
        {
            List<string> bannedWords = new List<string>() { "bad", "horrible" };
            apiClientService.Setup(e => e.GetContent()).Returns("This should censor bad and horrible words");
            wordDictionary.Setup(e => e.GetBannedWords()).Returns(bannedWords);
            string result = readerApplication.CensorText();

            Assert.AreEqual("This should censor b#d and h######e words", result);
        }
    }
}
