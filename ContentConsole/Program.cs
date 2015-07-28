namespace ContentConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ContentConsole.Core;

    public static class Program
    {
        public static void Main(string[] args)
        {
            // Should probably be an enum, not sure how to implement yet
            int userLevel;
            SharedMethod shared = new SharedMethod();

            Console.WriteLine("Content Editor");
            Console.WriteLine("\r\n1 - User");
            Console.WriteLine("2 - Administrator");
            Console.WriteLine("3 - Reader");
            Console.WriteLine("4 - Content Curator");

            Console.WriteLine("\r\nPlease select the number that corresponds to your access level. ");
            bool validNumber = int.TryParse(Console.ReadLine(), out userLevel);

            if (validNumber == false || userLevel > 4 || userLevel < 1)
            {
                Console.WriteLine("You have selected an invalid access level, press ANY key to try again.");
                Console.ReadLine();
                Console.Clear();
                Program.Main(new string[] { });
            }

            if (userLevel == 2)
            {
                AdminTools();
            }
            else
            {
                List<string> sentences = new List<string> {
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting."};

                foreach (string sentence in sentences)
                {
                    int badWordCount = shared.CountBannedWords(sentence);

                    Console.WriteLine("\r\nScanned the text:");

                    if (badWordCount == 0)
                    {
                        Console.WriteLine(sentence);
                    }
                    else
                    {
                        if (userLevel != 1 && userLevel != 4)
                        {
                            Console.WriteLine(shared.MaskBannedWords(sentence));
                        }
                        else
                        {
                            Console.WriteLine(sentence);
                        }
                    }

                    if (userLevel != 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Total Number of negative words: " + badWordCount);
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine("\r\nPress ANY key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// The method that is called
        /// if the user is an admin.
        /// </summary>
        private static void AdminTools()
        {
            SharedMethod shared = new SharedMethod();
            List<string> bannedList = shared.PrintBannedList();
            int selectedOption;

            PrintBannedList(bannedList);

            Console.WriteLine("\r\n1 - Add word(s) to list");
            Console.WriteLine("2 - Remove word(s) from list");
            Console.WriteLine("3 - Clear list");
            Console.WriteLine("Please select an option from the above.");
            bool validOption = int.TryParse(Console.ReadLine(), out selectedOption);

            if (validOption == false || selectedOption > 3 || selectedOption < 1)
            {
                Console.WriteLine("You have selected an invalid option, press ANY key to try again.");
                Console.ReadLine();
                Program.AdminTools();
            }

            if (selectedOption == 1)
            {
                Console.WriteLine("Please type the words to add to the list as comma seperated values.");

                List<string> wordsToAdd = new List<string>();
                wordsToAdd.AddRange(Console.ReadLine().Split(','));

                shared.AddWordsToBannedList(wordsToAdd);
                PrintBannedList(bannedList);
            }
            else if (selectedOption == 2)
            {
                Console.WriteLine("Please type the words to remove from the list as comma seperated values.");

                List<string> wordsToRemove = new List<string>();
                wordsToRemove.AddRange(Console.ReadLine().Split(','));

                shared.RemoveWordsFromBannedList(wordsToRemove);
                PrintBannedList(bannedList);
            }
            else if (selectedOption == 3)
            {
                Console.WriteLine(shared.ClearBannedList());
            }
        }

        /// <summary>
        /// Prints the current list of
        /// banned words to the console.
        /// </summary>
        /// <param name="bannedList">The list of banned words.</param>
        private static void PrintBannedList(List<string> bannedList)
        {
            int wordCount = 0;
            Console.WriteLine("\r\nThe list of banned words are:");

            foreach (string word in bannedList)
            {
                wordCount++;

                if (wordCount == bannedList.Count)
                {
                    Console.WriteLine(word);
                }
                else
                {
                    Console.WriteLine(word + ",");
                }
            }
        }
    }
}