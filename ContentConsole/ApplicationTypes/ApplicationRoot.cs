using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole
{
    public abstract class ApplicationRoot
    {
        private IApiClientService _apiClientService;
        private IBannedWordDictionary _wordDictionary;
        private IUserInputHandler _inputHandler;
  
        public ApplicationRoot(IApiClientService apiClientService,
            IBannedWordDictionary wordDictionary, IUserInputHandler inputHandler)
        {
            _apiClientService = apiClientService;
            _wordDictionary = wordDictionary;
            _inputHandler = inputHandler;
        }
        protected void RunCoreApp()
        {
            string content = _apiClientService.GetContent();
            ScanText(content);
            Console.WriteLine("Press ANY key to exit.");
            _inputHandler.ReadKey();
        }

        protected void ScanText(string content)
        {
            string originalText = _apiClientService.GetContent();
            List<string> bannedWords = _wordDictionary.GetBannedWords();
            
            int badWords = 0;

            foreach (string bannedWord in bannedWords)
            {
                if (originalText.Contains(bannedWord))
                {
                    badWords++;
                }
            }

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine($"Total Number of negative words: {badWords}");
        }

        public abstract void RunCustomApplication();
    }
}
