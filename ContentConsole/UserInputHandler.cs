using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole
{
    public class UserInputHandler : IUserInputHandler
    {
        public string InputLine()
        {
            return Console.ReadLine().ToLower();
        }

        public string YesNoHandling()
        {
            string errorText = "Invalid input. Press y/n to continue";

            string input = Console.ReadLine().ToLower();

            if (input == "y")
                return "y";

            if (input == "n")
                return "n";     

            Console.WriteLine(errorText);
            return YesNoHandling();
        }

        public string ReadKey()
        {
            return Console.ReadKey().Key.ToString();
        }
    }
}
