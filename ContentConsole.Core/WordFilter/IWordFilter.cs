using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public interface IWordFilter
    {
        /// <summary>
        /// THe filter state (enabled/disabled).
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Replaces all the occurences of words in text with the censored version.
        /// It only matches complete words, so Filter("badly", new[] { "bad" }) == "badly".
        /// </summary>
        /// <param name="text">The text to filter.</param>
        /// <param name="words">The words to censor.</param>
        /// <returns></returns>
        string Filter(string text, IEnumerable<string> words);
    }
}
