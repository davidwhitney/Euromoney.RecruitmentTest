using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ContentConsole
{
    public class NegativeWordCheck
    {
        public virtual NegativePhrase RunNegativeWordCheck(string text = null, bool enableFiltering = true)
        {
            var negativeWords = this.GetNegativeWords(new List<string>());

            var result = this.PhraseCheck(negativeWords, text, enableFiltering);

            return result;
        }

        public virtual NegativePhrase PhraseCheck(List<string> negativeWords, string text, bool enableFiltering)
        {
            var negativeWordCount = 0;

            foreach (var word in negativeWords)
            {
                negativeWordCount += Regex.Matches(text, @"\b" + word + @"\b").Count;

                if (!enableFiltering) continue;
                var safeWord = word.Replace(word.Substring(1, word.Length - 2), new string('#', word.Length - 2));
                text = Regex.Replace(text, @"\b" + word + @"\b", safeWord);
            }

            return new NegativePhrase() { NegativeWordCount = negativeWordCount, Phrase = text };
        }

        public virtual List<string> GetNegativeWords(List<string> negativeWords)
        {
            Console.WriteLine("\nPlease add a bad word and click enter");
            negativeWords.Add(Console.ReadLine());
            Console.WriteLine("Bad Word added, please press Y to add another word or Enter to continue");

            var key = Console.ReadKey().Key;

            if (key.Equals(System.ConsoleKey.Y))
            {
                GetNegativeWords(negativeWords);
            }

            return negativeWords;
        }
    }
}