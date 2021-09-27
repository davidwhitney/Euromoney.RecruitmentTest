using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public class NegativeWordsFilteration : INegativeWordsFilteration
    {
        private IDataStore dataStore = null;

        public NegativeWordsFilteration()
        {
            dataStore = new ArrayListDataStore();
        }

        /// <summary>
        /// Get count of negative words from the content
        /// </summary>
        public int NegativeWordCount(string content)
        {
            int numberOfNegativeWords = 0;
            string pattern = "[^\\w]";
            string[] contentWords = Regex.Split(content, pattern, RegexOptions.IgnoreCase);

            for (int i = contentWords.GetLowerBound(0); i <= contentWords.GetUpperBound(0); i++)
            {
                if (contentWords[i].ToString() != string.Empty)
                {
                    if (dataStore.checkBannedWords(contentWords[i]))
                    {
                        numberOfNegativeWords = numberOfNegativeWords + 1;
                    }
                }
            }

            return numberOfNegativeWords;
        }

        /// <summary>
        /// Add negative words in the data store
        /// </summary>
        public void AddNegativeWords(string word)
        {
            dataStore.addBannedWords(word);
        }

        /// <summary>
        /// Remove negative words in the data store
        /// </summary>
        public void RemoveNegativeWords(string word)
        {
            dataStore.removeBannedWords(word);
        }

        /// <summary>
        /// Filter negative words from the content based on isEnable flag
        /// </summary>
        public string FilterNegativeWords(string content, bool isEnable)
        {
            string updatedContent = content;
            if(isEnable)
            {
                updatedContent = ReplaceNegativeWords(updatedContent);
            }
            return updatedContent;
        }

        /// <summary>
        /// Replace negative words from the content
        /// </summary>
        private string ReplaceNegativeWords(string content)
        {
            string contentWithoutBadWords = content;
            string pattern = "[^\\w]";
            string[] contentWords = Regex.Split(content, pattern, RegexOptions.IgnoreCase);

            for (int i = contentWords.GetLowerBound(0); i <= contentWords.GetUpperBound(0); i++)
            {
                if (contentWords[i].ToString() != string.Empty)
                {
                    if (dataStore.checkBannedWords(contentWords[i]))
                    {
                        contentWithoutBadWords = replaceWords(contentWithoutBadWords, contentWords[i]);
                    }
                }
            }

            return contentWithoutBadWords;
        }

        private string replaceWords(string content, string word)
        {
            string replacedWord = word[0] + string.Concat(Enumerable.Repeat("#", word.Length - 2)) + word[word.Length - 1];
            string contentWithoutBadWord = content.Replace(word, replacedWord);

            return contentWithoutBadWord;
        }
    }
}
