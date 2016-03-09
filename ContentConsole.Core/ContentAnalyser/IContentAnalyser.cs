using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public interface IContentAnalyser
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Counts the total number of times any of the words appear in text (case insensitive).
        /// It only matches complete words, so Count("badly", new[] { "bad" }) == 0.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="words">The words to count.</param>
        /// <returns></returns>
        int CountNegativeWords();

        /// <summary>
        /// Replaces all the occurences of words in text with the censored version.
        /// It only matches complete words, so Filter("badly", new[] { "bad" }) == "badly".
        /// </summary>
        /// <param name="text">The text to filter.</param>
        /// <param name="words">The words to censor.</param>
        /// <returns></returns>
        string FilterNegativeWords();

        /// <summary>
        /// Enables the negative words filter.
        /// </summary>
        void EnableFilter();

        /// <summary>
        /// Disables the negative words filter.
        /// </summary>
        void DisableFilter();

        /// <summary>
        /// Add an entry to the negative words list.
        /// </summary>
        /// <param name="word">The word to add.</param>
        void AddNegativeWord(string word);

        /// <summary>
        /// Deletes an entry from the negative words list.
        /// </summary>
        /// <param name="word">The word to delete.</param>
        void DeleteNegativeWord(string word);

        /// <summary>
        /// Deletes all entries from the negative words list.
        /// </summary>
        void DeleteAllNegativeWords();

        /// <summary>
        /// Get the list of negative words.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetNegativeWords();
    }
}
