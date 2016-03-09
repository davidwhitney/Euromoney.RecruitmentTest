using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public interface IWordCounter
    {
        /// <summary>
        /// Counts the total number of times any of the words appear in text (case insensitive).
        /// It only matches complete words, so Count("badly", new[] { "bad" }) == 0.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="words">The words to count.</param>
        /// <returns></returns>
        int Count(string text, IEnumerable<string> words);
    }
}
