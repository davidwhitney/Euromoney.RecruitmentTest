using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.ApplicationTypes
{
    public class CuratorApplication : ApplicationRoot
    {
        private IApiClientService _apiClientService;
        private IBannedWordDictionary _wordDictionary;
        private IUserInputHandler _userInputHandler;
        public CuratorApplication(IApiClientService apiClientService, IBannedWordDictionary wordDictionary, IUserInputHandler userInputHandler)
            : base(apiClientService, wordDictionary, userInputHandler)
        {
            _apiClientService = apiClientService;
            _wordDictionary = wordDictionary;
            _userInputHandler = userInputHandler;
        }

        public override void RunCustomApplication()
        {
            ScanText(new ReaderApplication(_apiClientService,_wordDictionary, _userInputHandler).GetCensoredText());

            Console.WriteLine();
            Console.WriteLine("Press Y to remove censorship. \n");
            string input = _userInputHandler.InputLine();

            if (input == "y")
            {
                Console.WriteLine("Uncensored Text:");
                Console.WriteLine(_apiClientService.GetContent());
            }

            Console.WriteLine("Press ANY key to exit");
            Console.ReadKey();
        }
    }
}
