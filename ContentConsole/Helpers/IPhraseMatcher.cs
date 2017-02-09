using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Helpers
{
    /// <summary>
    /// Matches a set of phrases, find the location of the first match.
    /// </summary>
    public interface IPhraseMatcher
    {
        /// <summary>
        /// Matches the input to a list of phrases, returns the value of the matched phrase and it's location. 
        /// </summary>
        /// <param name="start">The location to start checking for matching phrases</param>
        /// <param name="input">The input to check</param>
        /// <param name="matchedPhrases">IEnumerable of phrases to match</param>
        /// <returns>A PhraseMatchResult containing the matched phrase and it's location, or null if no matches are found.</returns>
        PhraseMatchResult Match(int start, string input, IEnumerable<string> matchedPhrases);
    }
}
