using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.ApplicationTypes
{
    public class AdminApplication : ApplicationRoot
    {
        private IApiClientService _apiClientService;
        private IBannedWordDictionary _wordDictionary;
        private IUserInputHandler _userInputHandler;
        private List<string> bannedWords;
        public AdminApplication(IApiClientService apiClientService, IBannedWordDictionary wordDictionary, IUserInputHandler userInputHandler)
            : base(apiClientService, wordDictionary, userInputHandler)
        {
            _apiClientService = apiClientService;
            _wordDictionary = wordDictionary;
            _userInputHandler = userInputHandler;
        }

        public override void RunCustomApplication()
        {
            Console.WriteLine("Do you want to edit the banned word dictionary? y/n");

            string input = _userInputHandler.YesNoHandling();

            if(input == "y")
            {
                ManageDicitonary();
            }
            else if (input == "n")
            {
                RunCoreApp();
            }
        }

        private void ManageDicitonary()
        {
            PrintDictionary();
            Console.WriteLine();
            HandleModification();          
        }

        private void PrintDictionary()
        {
            bannedWords = _wordDictionary.GetBannedWords();
            Console.WriteLine("Current Dictionary:");
            foreach (string word in bannedWords)
            {
                Console.WriteLine($" - {word}");
            }
        }

        private void HandleModification()
        {
            Console.WriteLine("To add values, type ADD");
            Console.WriteLine("To remove values, type DEL");

            string input = _userInputHandler.InputLine();

            if (input == "add")
            {
                AddValues();
            }
            else if (input == "del")
            {
                DeleteValues();
            }
            else
            {
                Console.WriteLine("Invalid term. Press ANY key to try again");
                Console.ReadKey();
                HandleModification();
            }
        }

        private void AddValues()
        {
            Console.WriteLine();
            Console.WriteLine("Please type a word you would like to add to the list.");

            string input = _userInputHandler.InputLine();

            if (input == "")
            {
                Console.WriteLine("Invalid word. Please try again.");
                AddValues();
            }

            if (bannedWords.Contains(input))
            {
                Console.WriteLine("Value already exists. Please try again");
                AddValues();
            }

            _wordDictionary.AddWord(input);

            Console.WriteLine("Word successfully added. Would you like to add another? y/n? \n");
            string carryOn = _userInputHandler.YesNoHandling();

            PrintDictionary();

            if (carryOn == "y")
            {
                AddValues();
                return;
            }

            CheckContinue();
        }

        private void DeleteValues()
        {
            Console.WriteLine();
            Console.WriteLine("Please type a word you would like to remove from the list.");

            string input = _userInputHandler.InputLine();

            if (input == "")
            {
                Console.WriteLine("Invalid word. Please try again.");
                DeleteValues();
            }

            if (!bannedWords.Contains(input))
            {
                Console.WriteLine("Value does not exist. Please try again.");
                DeleteValues();
            }

            _wordDictionary.DeleteWord(input);

            Console.WriteLine("Word successfully removed. Would you like to remove another? y/n? \n");
            string carryOn = _userInputHandler.YesNoHandling();

            PrintDictionary();

            if (carryOn == "y")
            {
                DeleteValues();
                return;
            }

            CheckContinue();
        }

        private void CheckContinue()
        {
            Console.WriteLine("Would you like to continue editing the list? y/n?\n");
            string input = _userInputHandler.YesNoHandling();

            if (input == "y")
            {
                HandleModification();
            }
            else if (input != "n")
            {
                Console.WriteLine("Invalid input. Please try again.");
                CheckContinue();
                return;
            }
            else
            {
                RunCoreApp();
                return;
            }
        }
    }
}
