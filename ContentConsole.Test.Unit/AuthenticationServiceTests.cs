using ContentConsole.ApplicationTypes;
using ContentConsole.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Test.Unit
{
    class AuthenticationServiceTests
    {
        private Mock<IApiClientService> apiClientService;
        private Mock<IBannedWordDictionary> wordDictionary;
        private Mock<IUserInputHandler> inputHandler;
        private AuthenticationService authenticationService;

        [SetUp]
        public void Setup()
        {
            apiClientService = new Mock<IApiClientService>();
            wordDictionary = new Mock<IBannedWordDictionary>();
            inputHandler = new Mock<IUserInputHandler>();
            authenticationService = new AuthenticationService(apiClientService.Object, wordDictionary.Object, inputHandler.Object);
        }

        [Test]
        public void ShouldAuthenticateToUserAsDefault()
        {
            inputHandler.Setup(e => e.InputLine()).Returns("e");
            inputHandler.Setup(e => e.YesNoHandling()).Returns("n");
            authenticationService.PromptUserForAuth();

            var appToRun = authenticationService.GetUserRole();

            Assert.AreEqual(appToRun.GetType(), typeof(UserApplication));
        }

        [Test]
        public void ShouldAuthenticateAdminCorrectly()
        {
            inputHandler.Setup(e => e.InputLine()).Returns("administrator");
            authenticationService.PromptUserForAuth();

            var appToRun = authenticationService.GetUserRole();

            Assert.AreEqual(appToRun.GetType(), typeof(AdminApplication));
        }

        [Test]
        public void ShouldAuthenticateUserCorrectly()
        {
            inputHandler.Setup(e => e.InputLine()).Returns("user");
            authenticationService.PromptUserForAuth();

            var appToRun = authenticationService.GetUserRole();

            Assert.AreEqual(appToRun.GetType(), typeof(UserApplication));
        }

        [Test]
        public void ShouldAuthenticateCuratorCorrectly()
        {
            inputHandler.Setup(e => e.InputLine()).Returns("content curator");
            authenticationService.PromptUserForAuth();

            var appToRun = authenticationService.GetUserRole();

            Assert.AreEqual(appToRun.GetType(), typeof(CuratorApplication));
        }

        [Test]
        public void ShouldAuthenticateReaderCorrectly()
        {
            inputHandler.Setup(e => e.InputLine()).Returns("reader");
            authenticationService.PromptUserForAuth();

            var appToRun = authenticationService.GetUserRole();

            Assert.AreEqual(appToRun.GetType(), typeof(ReaderApplication));
        }
    }
}
