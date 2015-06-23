using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class TextAnalyser
    {
        /// <summary>
        /// A collection of case insensitive unique bad words
        /// </summary>
        private readonly IList<string> badWords;

        public TextAnalyser(IList<string> badWords)
        {
            this.badWords = badWords;
        }

        public int Analyse(string text)
        {
            //TODO: this works for the given string but it would fail with other cases, regular expressions could be used instead.
            char[] splitCharacters = new[] { ' ', '.' };
            string[] words = text.Split(splitCharacters);

            int count = 0;
            foreach(var word in words)
            {
                if(badWords.Contains(word, StringComparer.InvariantCultureIgnoreCase))
                    count++;
            }

            return count;
        }

        public string Filter(string text)
        {
            var filteredPhrase = new StringBuilder(text);
            var comparison = StringComparison.InvariantCultureIgnoreCase;

            foreach(string badword in badWords)
            {
                int index = text.IndexOf(badword, comparison);
                if(index != -1)
                {
                    for(int i = index + 1; i < index + badword.Length - 1; i++)
                    {
                        filteredPhrase[i] = '#';
                    }
                }
            }
            return filteredPhrase.ToString();
        }

        public void AddBadWord(string word)
        {
            if (badWords.Contains(word, StringComparer.InvariantCultureIgnoreCase))
                return;

            badWords.Add(word);
        }

        public void RemoveBadWord(string word)
        {
            int index;
            bool foundOne = false;
            for (index = 0; index < badWords.Count; index++)
            {
                if (0 == String.Compare(badWords[index], word, StringComparison.InvariantCultureIgnoreCase))
                {
                    foundOne = true;
                    break;
                }
            }

            //there is only one to be found given that all IList<string> badWords elements are unique
            if (foundOne)
            {
                badWords.RemoveAt(index);
            }
        }

        public int CountBadWords()
        {
            return badWords.Count;
        }
    }
}
