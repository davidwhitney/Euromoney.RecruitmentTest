using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace ContentConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BannedWord> bannedWord = null;
            IContentManagement contentManagement = new ContentManagement();
            string content = "";
            string response = "";
            string pathDataStorage = Environment.CurrentDirectory.ToString() + "/../../TestData/";
            string[] arrBannedWords = File.ReadAllLines(pathDataStorage + "BannedWord.txt");

            Console.WriteLine("Content Management Console");
            Console.WriteLine("");

            //Text proposal
            Console.WriteLine("Please enter YES if you want to scan default text, otherwise press any key.");
            response = Console.ReadLine();
            if (response.ToLower() == "y" || response.ToLower() == "yes")
            {
                content = File.ReadAllText(pathDataStorage + "Text.txt");
            }
            else
            {
                Console.Write("Please enter the suggested text: ");
                content = Console.ReadLine();
            }

            //Story selections
            Console.WriteLine("");
            Console.WriteLine("Please select Story you want to test (enter number of story):\n\n 1. User story \n 2. Administrator story \n 3. Reader story \n 4. Content curator story \n");
            response = Console.ReadLine();
            if (response == "1")
            {
                bannedWord = contentManagement.BannedWordCounter(content, arrBannedWords);
            }
            else if (response == "2")
            {
                //Bad words proposal
                Console.WriteLine("Please enter new banned words separated by comma and press ENTER.");
                response = Console.ReadLine();

                //Storing this set of new banned words in the data storage (text file)
                var path = pathDataStorage + "NewBannedWords.txt";
                File.WriteAllText(path, response);

                //Get stored banned word from data storage
                response = File.ReadAllText(path);

                bannedWord = contentManagement.BannedWordCounter(content, response);
            }
            else if (response == "3")
            {
                content = contentManagement.BannedWordReplacer(content, arrBannedWords);
            }
            else if (response == "4")
            {
                //Display original content with negative words count (similar to story 1, not totally understand the task for this story, need clarifications)
                bannedWord = contentManagement.BannedWordCounter(content, arrBannedWords);
            }
            else
            {
                Console.WriteLine("Invalid request.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);

            if (bannedWord != null)
            {
                int badWordsTotal = 0;
                foreach (BannedWord word in bannedWord)
                {
                    Console.WriteLine("");
                    Console.Write("Number of '{0}' : ", word.Word);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", word.Count);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    badWordsTotal += word.Count;
                }

                Console.WriteLine("\n");
                Console.Write("Total Number of negative words : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}", badWordsTotal);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("\n");
            Console.WriteLine("Press any key for EXIT");
            Console.ReadKey();

        }
    }

}
