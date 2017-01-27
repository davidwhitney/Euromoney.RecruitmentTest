using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ContentManagement _contentManagement = new ContentManagement();
            List<BannedWord> _bannedWord = null;

            string[] arrBannedWords = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "/../../TestData/BannedWord.txt");

            string content = "";
            string response = "";

            Console.WriteLine("Content Management Console");
            Console.WriteLine("");

            //Text proposal
            Console.WriteLine("Please enter YES if you want to scan default text, otherwise press any key.");
            response = Console.ReadLine();
            if (response.ToLower() == "y" || response.ToLower() == "yes")
            {
                content = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/../../TestData/Text.txt");
            }
            else
            {
                Console.Write("Please enter the suggested text: ");
                content = Console.ReadLine();
            }

            //Story selections
            Console.WriteLine("");
            Console.WriteLine("What Story you want to test (please enter number of story)?\n 1. User story \n 2. Administrator story \n 3. Reader story \n 4. Content curator story \n");
            response = Console.ReadLine();
            if (response == "1")
            {
                _bannedWord = _contentManagement.BannedWordCounter(content, arrBannedWords);
            }
            else if (response == "2")
            {
                //Bad words proposal
                Console.WriteLine("Please enter new banned words separated by comma and press ENTER.");
                response = Console.ReadLine();
                _bannedWord = _contentManagement.BannedWordCounter(content, response);
            }
            else if (response == "3")
            {
                content = _contentManagement.BannedWordReplacer(content, arrBannedWords);
            }
            else if (response == "4")
            {
                //Display original content with negative words count (similar to story 1, not totally understand the task for this story)
                _bannedWord = _contentManagement.BannedWordCounter(content, arrBannedWords);
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
            Console.WriteLine("");

            if (_bannedWord != null)
            {
                int badWordsTotal = 0;
                foreach (BannedWord word in _bannedWord)
                {
                    badWordsTotal += word.Count;
                    Console.WriteLine("Number of '{0}' : {1}", word.Word, word.Count);
                }

                Console.WriteLine("");
                Console.WriteLine("Total Number of negative words : {0}", badWordsTotal);
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key for EXIT");
            Console.ReadKey();

        }
    }

}
