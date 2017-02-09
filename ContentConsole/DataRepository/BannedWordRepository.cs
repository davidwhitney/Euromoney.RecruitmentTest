using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.DataRepository
{

    /// <summary>
    /// Banned word repository 
    /// </summary>
    public class BannedWordRepository : IBannedWordRepository
    {
        // Set of banned words in lowercase. 
        private readonly ISet<string> _lowercaseBannedWordSet;

        public BannedWordRepository()
        {
            _lowercaseBannedWordSet = new HashSet<string>();
        }

        /// <summary>
        /// Get all of the banned words. 
        /// </summary>
        /// <returns>IEnumerable of words, not guaranteed to be in the same case as they were provided.
        /// </returns>
        public IEnumerable<string> GetAll()
        {
            return _lowercaseBannedWordSet;
        }

        /// <summary>
        ///  Add a word if it doesn't exist in our set
        /// </summary>
        /// <param name="bannedWord">Word to add</param>
        public void Add(string bannedWord)
        {
            // Do not add null words
            if (bannedWord == null)
            {
                return;
            }

            string lowercaseTrimmedBannedWord = bannedWord.Trim().ToLower();

            // Do not add empty words
            if (lowercaseTrimmedBannedWord.Length == 0)
            {
                return;
            }

            if (!Contains(lowercaseTrimmedBannedWord))
            {
                _lowercaseBannedWordSet.Add(lowercaseTrimmedBannedWord);
            }
        }

        /// <summary>
        /// Whether the banned word exists in the repository. Case insensitive. 
        /// </summary>
        /// <param name="bannedWord">The word to check</param>
        /// <returns>True if the repository contains the word, false otherwise</returns>
        public bool Contains(string bannedWord)
        {
            // Return false on null
            if (bannedWord == null)
            {
                return false;
            }

            string lowercaseTrimmedBannedWord = bannedWord.Trim().ToLower();

            // Return false on empty word
            if (lowercaseTrimmedBannedWord.Length == 0)
            {
                return false;
            }

            return _lowercaseBannedWordSet.Contains(lowercaseTrimmedBannedWord);
        }

        /// <summary>
        /// Remove the banned word if it exists. Case insensitive. 
        /// </summary>
        /// <param name="bannedWord">The word to remove</param>
        public void Remove(string bannedWord)
        {
            if (bannedWord == null)
            {
                return;
            }

            string lowercaseTrimmedBannedWord = bannedWord.Trim().ToLower();

            if (lowercaseTrimmedBannedWord.Length == 0)
            {
                return;
            }

            if (Contains(lowercaseTrimmedBannedWord))
            {
                _lowercaseBannedWordSet.Remove(lowercaseTrimmedBannedWord);
            }
        }
    }
}
