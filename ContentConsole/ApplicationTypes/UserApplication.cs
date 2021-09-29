using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Interfaces
{
    public class UserApplication : ApplicationRoot
    {
        private IApiClientService _apiClientService;
        private IBannedWordDictionary _wordDictionary;
        public UserApplication(IApiClientService apiClientService, IBannedWordDictionary wordDictionary, IUserInputHandler inputHandler) 
            : base(apiClientService, wordDictionary, inputHandler)
        {
            _apiClientService = apiClientService;
            _wordDictionary = wordDictionary;
        }

        public override void RunCustomApplication() => RunCoreApp();
    }
}
