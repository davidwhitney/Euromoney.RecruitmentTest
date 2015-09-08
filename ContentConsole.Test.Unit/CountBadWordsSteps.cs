using Shouldly;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;

namespace ContentConsole.Test.Unit
{
    [Binding]
    public class CountBadWordsSteps
    {
        const string INPUT_KEY = "input";
        const string BAD_WORDS_COUNT_KEY = "badwordscount";
        private TextParser _textParser
        {
            get
            {
                return ScenarioContext.Current.Get<TextParser>();
            }
            set
            {
                ScenarioContext.Current.Set(value);
            }
        }
        private string _input
        {
            get
            {
                return ScenarioContext.Current.Get<string>(INPUT_KEY);
            }
            set
            {
                ScenarioContext.Current.Set(value, INPUT_KEY);
            }
        }
        private int _badWordsCount
        {
            get
            {
                return ScenarioContext.Current.Get<int>(BAD_WORDS_COUNT_KEY);
            }
            set
            {
                ScenarioContext.Current.Set(value, BAD_WORDS_COUNT_KEY);
            }
        }

        private IBannedWords _bannedWords
        {
            get
            {
                return ScenarioContext.Current.Get<IBannedWords>();
            }
            set
            {
                ScenarioContext.Current.Set(value);
            }
        }

        [Given(@"The banned words are")]
        public void GivenTheBannedWordsAre(Table bannedWords)
        {
            List<string> bannedWordList = new List<string>();
            foreach (var word in bannedWords.Rows)
            {
                bannedWordList.Add(word["bannedWords"]);
            };
            var bannedWordsMock = new Moq.Mock<IBannedWords>();
            bannedWordsMock.SetupGet(x => x.List).Returns(bannedWordList);
            _bannedWords = bannedWordsMock.Object;
        }


        [Given(@"I have a text parser")]
        public void GivenIHaveATextParser()
        {
            _textParser = new TextParser(_bannedWords);
        }

        [Given(@"I have the input ""(.*)""")]
        public void GivenIHaveTheInput(string input)
        {
            _input = input;
        }

        [When(@"I evaluate the message")]
        public void WhenIEvaluateTheMessage()
        {
            _badWordsCount = _textParser.CountBadWords(_input);
        }

        [Then(@"the number of bad words should be (.*)")]
        public void ThenTheNumberOfBadWordsShouldBe(int numberBadWords)
        {
            _badWordsCount.ShouldBe(numberBadWords);
        }
    }
}
