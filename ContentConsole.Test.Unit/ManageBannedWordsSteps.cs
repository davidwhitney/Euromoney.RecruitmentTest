using System.Linq;
using TechTalk.SpecFlow;
using Shouldly;

namespace ContentConsole.Test.Unit
{
    [Binding]
    public class ManageBannedWordsSteps
    {
        const string CURRENT_WORD = "currentWord";
        private ITempFileProvider _tempFileProvider
        {
            get
            {
                return ScenarioContext.Current.Get<ITempFileProvider>();
            }
            set
            {
                ScenarioContext.Current.Set<ITempFileProvider>(value);
            }
        }

        private BannedWords _bannedWords
        {
            get
            {
                return ScenarioContext.Current.Get<BannedWords>();
            }
            set
            {
                ScenarioContext.Current.Set<BannedWords>(value);
            }
        }

        private string _currentWord
        {
            get
            {
                return ScenarioContext.Current.Get<string>(CURRENT_WORD);
            }
            set
            {
                ScenarioContext.Current.Set<string>(value,CURRENT_WORD);
            }
        }

        [Given(@"I have a banned words manager")]
        public void GivenIHaveABannedWordsManager()
        {
            _bannedWords = new BannedWords(_tempFileProvider);
        }

        [Given(@"bad is a banned word")]
        public void GivenBadIsABannedWord()
        {
            var tempFileProviderMock = new Moq.Mock<ITempFileProvider>();
            tempFileProviderMock.Setup(x => x.ReadContent()).Returns("bad");
            _tempFileProvider = tempFileProviderMock.Object;
        }


        [Given(@"I want to add (.*)")]
        public void GivenIWantToAdd(string wordToAdd)
        {
            _currentWord = wordToAdd;
        }
        
        [When(@"I add to the list or words (.*) time")]
        public void WhenIAddToTheListOrWordsTime(int numberOfAdds)
        {
            for (int i = 0; i < numberOfAdds; i++)
            {
                _bannedWords.AddWord(_currentWord);
            }
        }
        
        [Then(@"(.*) must appear (.*)")]
        public void ThenMustAppear(string word, int numberOfTimes)
        {
            _bannedWords.List.Count(x => x == word).ShouldBe(numberOfTimes);
        }
    }
}
