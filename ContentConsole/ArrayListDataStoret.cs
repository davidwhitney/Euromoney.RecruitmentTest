using System;
using System.Collections;

namespace ContentConsole
{
    public class ArrayListDataStore : IDataStore
    {

        private ArrayList bannedWords;

        public ArrayListDataStore()
        {
            bannedWords = new ArrayList();
        }

        /// <summary>
        /// Add words in the banned word data store
        /// </summary>
        public void addBannedWords(string bannedWord)
        {
            bannedWords.Add(bannedWord.ToLower());
        }

        /// <summary>
        /// Remove words from the banned word data store
        /// </summary>
        public void removeBannedWords(string bannedWord)
        {
            bannedWords.Remove(bannedWord);
        }

        /// <summary>
        /// Check if the word is present in the banned word data store
        /// </summary>
        public bool checkBannedWords(string word)
        {
            bool isBannedWord = false;

            if (bannedWords.Contains(word.ToLower()))
            {
                isBannedWord = true;
            }

            return isBannedWord;
        }
    }
}
