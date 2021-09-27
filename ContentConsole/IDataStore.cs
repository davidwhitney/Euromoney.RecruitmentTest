using System;

namespace ContentConsole
{
    public interface IDataStore
    {
        /// <summary>
        /// Add words in the banned word data store
        /// </summary>
        void addBannedWords(string bannedWord);

        /// <summary>
        /// Remove words from the banned word data store
        /// </summary>
        void removeBannedWords(string bannedWord);

        /// <summary>
        /// Check if the word is present in the banned word data store
        /// </summary>
        bool checkBannedWords(string word);
    }
}
