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
    public class PhraseMatcher : IPhraseMatcher
    {
        private readonly static List<char> Whitespace = new List<char>() { '\t', '\n', ' ' };
        private readonly static List<char> Punctuation = new List<char>() { '.', '-', '?', '!', '&' };

        /// <summary>
        /// Check whether the input character is whitepsace or punctuation 
        /// </summary>
        /// <param name="c">The character to check</param>
        /// <returns>True if whitespace or punctuation, false otherwise</returns>
        private static bool IsWhiteSpaceOrPunctuation(char c)
        {
            return Whitespace.Contains(c) || Punctuation.Contains(c);
        }

        /// <summary>
        /// Return the location of the matched phrase in the input, starting at the start location
        /// </summary>
        /// <param name="start">The location to start checking</param>
        /// <param name="input">The input sentence</param>
        /// <param name="matchedPhrase">The phrase to check</param>
        /// <returns>Location of the instance of the matched phrase, -1 if not found</returns>
        private int FindNextMatch(int start, string input, string matchedPhrase)
        {
            int nextPosition = input.ToLower().Substring(start).IndexOf(matchedPhrase.ToLower());

            // No match found
            if (nextPosition == -1)
            {
                return -1;
            }
            else
            {
                int absoluteMatchPosition = start + nextPosition;

                // Match found, check it's bounds are either the start or end of the string, whitespace, or punctuation
                bool isLeftBoundValid = absoluteMatchPosition == 0 ||
                                        IsWhiteSpaceOrPunctuation(input[absoluteMatchPosition - 1]);

                // Check that the right bound is either the end of the string, whitespace char, or punctuatoin
                bool isRightBoundValid = absoluteMatchPosition + matchedPhrase.Length == input.Length;
                if (!isRightBoundValid)
                {
                    isRightBoundValid = IsWhiteSpaceOrPunctuation(input[absoluteMatchPosition + matchedPhrase.Length]);
                }

                // Check bounds are valid
                bool isValidMatch = isLeftBoundValid && isRightBoundValid;

                // If the match is valid then return it.
                if (isValidMatch)
                {
                    return absoluteMatchPosition;
                }
                else
                {
                    // Otherwise return the next match.
                    return FindNextMatch(start + nextPosition + 1, input, matchedPhrase);
                }
            }
        }

        /// <summary>
        /// Creates a mapping of each phrase to the next instance in the input. 
        /// </summary>
        /// <param name="start">the location in the phrase to start checking for matches</param>
        /// <param name="input">the input string to check</param>
        /// <param name="matchedPhrases">An IEnumerable of phrases to check</param>
        /// <returns>A mapping of each phrase to the next location in the input, or -1 if the phrase is not found</returns>
        private IDictionary<string, int> FindNextMatches(int start, string input, IEnumerable<string> matchedPhrases)
        {
            IDictionary<string, int> nextMatches = new Dictionary<string, int>();
            foreach (string matchedPhrase in matchedPhrases)
            {
                nextMatches[matchedPhrase] = FindNextMatch(start, input, matchedPhrase);
            }
            return nextMatches;
        }

        /// <summary>
        /// Matches the input to a list of phrases, returns the value of the matched phrase and it's location. 
        /// </summary>
        /// <param name="start">The location to start checking for matching phrases</param>
        /// <param name="input">The input to check</param>
        /// <param name="matchedPhrases">IEnumerable of phrases to match</param>
        /// <returns>A PhraseMatchResult containing the matched phrase and it's location, or null if no matches are found.</returns>
        public PhraseMatchResult Match(int start, string input, IEnumerable<string> matchedPhrases)
        {
            IDictionary<string, int> nextMatches = FindNextMatches(start, input, matchedPhrases);

            // Find the phrase with the lowest matching non -1 position. If none are found return null.
            string lowestMatchingPhrase = null;
            int lowestMatchingPosition = Int32.MaxValue;

            foreach (string matchedPhrase in nextMatches.Keys)
            {
                int matchPosition = nextMatches[matchedPhrase];
                if (matchPosition > -1 && matchPosition < lowestMatchingPosition)
                {
                    lowestMatchingPhrase = matchedPhrase;
                    lowestMatchingPosition = matchPosition;
                }
            }

            if (lowestMatchingPhrase == null)
            {
                return null;
            }
            else
            {
                return new PhraseMatchResult()
                {
                    Index = lowestMatchingPosition,
                    MatchedPhrase = lowestMatchingPhrase
                };
            }
        }
    }
}

