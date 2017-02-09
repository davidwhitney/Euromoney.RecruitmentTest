using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.DataRepository
{
    /// <summary>
    /// A repository of banned words
    /// </summary>
    public interface IBannedWordRepository
    {
        /// <summary>
        /// Get all of the banned words. 
        /// </summary>
        /// <returns>IEnumerable of words, not guaranteed to be in the same case as they were provided.
        /// </returns>
        IEnumerable<string> GetAll();

        /// <summary>
        ///  Add a word if it doesn't exist in our set
        /// </summary>
        /// <param name="bannedWord">Word to add</param>
        void Add(string bannedWord);

        /// <summary>
        /// Whether the banned word exists in the repository. Case insensitive. 
        /// </summary>
        /// <param name="bannedWord">The word to check</param>
        /// <returns>True if the repository contains the word, false otherwise</returns>
        bool Contains(string bannedWord);

        /// <summary>
        /// Remove the banned word if it exists. Case insensitive. 
        /// </summary>
        /// <param name="bannedWord">The word to remove</param>// Remove word if it exists
        void Remove(string bannedWord);
    }
}
