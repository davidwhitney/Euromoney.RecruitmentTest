using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ContentConsole
{
    public static class Program
    {
        private static string originalContent = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        public static string OriginalContent 
        {
            get { return originalContent; }
            set { originalContent = value; }
        }

        public static void Main(string[] args)
        {
            bool enableFilter = true;
            var context = new BadWordContext();

            Console.WriteLine("Disable negative word filtering? (y/n)");
            ConsoleKeyInfo answer = Console.ReadKey(true);
            
            if (answer.Key == ConsoleKey.Y)
            {
                enableFilter = false;  
            }
            
            Console.WriteLine("Scanned the text:");            
            int badWordsCount = GetBadWordsCount(OriginalContent, context.BadWords);
            Console.WriteLine(GetContent(OriginalContent, context.BadWords, enableFilter));
            Console.WriteLine("Total Number of negative words: " + badWordsCount);
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Returns the number of bad words in the content
        /// </summary>
        /// <param name="content"></param>
        /// <param name="badWords"></param>
        /// <returns></returns>
        public static int GetBadWordsCount(string content, List<BadWord> badWords)
        {
            int badWordsCount = 0;

            foreach (BadWord word in badWords)
            { 
                if (content.Contains(word.Text))
                {
                    badWordsCount++;
                }
            }

            return badWordsCount;
        }

        /// <summary>
        /// Returns either the original content or with the "bad words" filtered
        /// </summary>
        /// <param name="content"></param>
        /// <param name="badWords"></param>
        /// <param name="filtered"></param>
        /// <returns></returns>
        public static string GetContent(string content, List<BadWord> badWords, bool filtered = true)
        {
            if (filtered)
            {
                foreach (BadWord word in badWords)
                {
                    if (content.Contains(word.Text))
                    {
                        content = content.Replace(word.Text, FilterWord(word.Text));
                    }
                }
            }

            return content;
        }

        /// <summary>
        /// Filters a word in this format: "f####t"
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string FilterWord(string word)
        {
            var letters = word.ToCharArray();

            for (int i = 1; i < letters.Length-1; i++)
            {
                letters[i] = '#';
            }

            return new string(letters);
        }
    }
}
