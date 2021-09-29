using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace ContentConsole
{
    public class AuthenticationHandler
    {
   
        private IAuthenticationService _authService;
    
        public AuthenticationHandler(
            IApiClientService apiClientService,
            IAuthenticationService authService,
            IBannedWordDictionary wordDictionary)
        {
            _authService = authService;
        }

        public void HandleAuth()
        {
            _authService.PromptUserForAuth();

            _authService.GetUserRole().RunCustomApplication();
        }
    }
}
