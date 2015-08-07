using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class ConsoleOutput
    {

        private string[] words;
        private string text;
        private bool showHide;
        public ConsoleOutput(string[] args, string content, bool trueShow)//controls the output to the console
        {
            words = args;
            text = content;
            showHide = trueShow;
            CheckWords();
            if (showHide == true)
            {
                ShowBadWords();
            }
            else
            {
                HideBadWords();
            }

        }
        public int CheckWords()// counts and displays the number of banned words
        {
            int badWords = 0;

            foreach (string bannedWord in words)
            {
                if (text.Contains(bannedWord))
                {
                    badWords = badWords + 1;
                }
            }
            Console.WriteLine("The program scanned the text:");
            Console.WriteLine(text);
            Console.WriteLine("Total Number of negative words found: " + badWords);
            return badWords;//just for testing
        }

        private void HideBadWords()
        {
            string modified = text;
            foreach (string bannedWord in words)
            {

                char[] temporaryWord = bannedWord.ToCharArray();
                int l = bannedWord.Length -1;//as the array is zero indexed
                for (int i = 1; i < l; i++)//leaves only the first and last letters intact
                {
                    temporaryWord[i] = '#';
                }
                string cleanedWord = new string(temporaryWord);
                modified = modified.Replace(bannedWord, cleanedWord);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Cleaned Text: ");
            Console.WriteLine(modified);
            
        }

        private void ShowBadWords()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The original text with Bad Words:");
            Console.WriteLine(text);
            
        }

        public void SpaceText()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
    }


}
