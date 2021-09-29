using ContentConsole.ApplicationTypes;
using ContentConsole.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentConsole
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<string> roles = new List<string>() { "user", "administrator", "reader", "content curator" };
        private readonly string defaultRole = "user";
        private string authStatus = "";
        private IApiClientService _apiClientService;
        private IBannedWordDictionary _bannedWordDictionary;
        private IUserInputHandler _userInputHandler;

        public AuthenticationService(
            IApiClientService apiClientService,
            IBannedWordDictionary bannedWordDictionary,
            IUserInputHandler userInputHandler)
        {
            _apiClientService = apiClientService;
            _bannedWordDictionary = bannedWordDictionary;
            _userInputHandler = userInputHandler;
        }

        public void PromptUserForAuth()
        {
            Console.WriteLine($"Please state your authorisation status:\n{GetAdminRoles()}");
            SetUserRole(_userInputHandler.InputLine());
        }

        private string GetAdminRoles()
        {
            string roleList = "";
            foreach(string role in roles)
            {
                roleList += $" - {role} \n";
            }

            return roleList;
        }

        private void SetUserRole(string input)
        {
            if (roles.Any(e => e.Equals(input.ToLower())))
            {
                Console.WriteLine($"Setting role to {input}. \n");
                authStatus = input;
            }
            else
            {
                ManageFailedRole();
            }
        }

        private void ManageFailedRole()
        {
            Console.WriteLine("Invalid role entered. \n Try again? y/n");
            string tryAgain = _userInputHandler.YesNoHandling();

            if (tryAgain == "y")
            {
                PromptUserForAuth();
            }
            else
            {
                Console.WriteLine($"Setting role to default: {defaultRole} \n");
                authStatus = defaultRole;
            }
        }

        public ApplicationRoot GetUserRole()
        {
            ApplicationRoot appToRun = null;
            switch (authStatus)
            {
                case "user":
                    {
                        appToRun = new UserApplication(_apiClientService, _bannedWordDictionary, _userInputHandler);
                    }
                    break;
                case "administrator":
                    {
                        appToRun = new AdminApplication(_apiClientService, _bannedWordDictionary, _userInputHandler);
                    }
                    break;
                case "reader":
                    {
                        appToRun = new ReaderApplication(_apiClientService, _bannedWordDictionary, _userInputHandler);
                    }
                    break;
                case "content curator":
                    {
                        appToRun = new CuratorApplication(_apiClientService, _bannedWordDictionary, _userInputHandler);
                    }
                    break;
            }

            return appToRun;
        }
    }
}
