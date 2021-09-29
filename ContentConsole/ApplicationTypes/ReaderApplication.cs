using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.ApplicationTypes
{
    public class ReaderApplication : ApplicationRoot
    {
        private IApiClientService _apiClientService;
        private IBannedWordDictionary _wordDictionary;
        public ReaderApplication(IApiClientService apiClientService, IBannedWordDictionary wordDictionary, IUserInputHandler inputHandler)
            : base(apiClientService, wordDictionary, inputHandler)
        {
            _apiClientService = apiClientService;
            _wordDictionary = wordDictionary;
        }

        public override void RunCustomApplication()
        {
            ScanText(CensorText());
            Console.WriteLine("Press ANY key to exit.");
        }

        public string CensorText()
        {
            List<string> bannedWords = _wordDictionary.GetBannedWords();
            string content = _apiClientService.GetContent();

            foreach (string bannedWord in bannedWords)
            {
                content = content.Replace(bannedWord, CensorWord(bannedWord));
            }

            return content;
        }

        public string GetCensoredText()
        {
            return CensorText();
        }

        private string CensorWord(string word)
        {
            string censor = "";
            string inner = word.Substring(1, word.Length - 2);

            for(int i = 0; i < inner.Length; i++)
            {
                censor += "#";
            }

            string result = word.Replace(inner, censor);
            return result;
        }
    }
}

