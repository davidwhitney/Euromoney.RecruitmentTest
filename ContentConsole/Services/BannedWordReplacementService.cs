using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Helpers;

namespace ContentConsole.Services
{
    /// <summary>
    /// Replaces banned words with another character
    /// </summary>
    public class BannedWordReplacementService : IBannedWordReplacementService
    {
        private readonly IBannedWordRetrievalService _bannedWordRetrievalService;
        private readonly IPhraseMatcher _matcher;
        public BannedWordReplacementService(IBannedWordRetrievalService bannedWordRetrievalService, IPhraseMatcher matcher)
        {
            _bannedWordRetrievalService = bannedWordRetrievalService;
            _matcher = matcher;
        }

        /// <summary>
        /// Replaces banned words with the replacement character. 
        /// If the words are less than three characters long then the entire word is replaced, 
        /// otherwise only the first and last characters will be shown.
        /// </summary>
        /// <param name="content">The content to process</param>
        /// <param name="replacementCharacter">The character to replace the banned word characters with</param>
        /// <returns>A string with the banned words replaced.</returns>
        public string ReplaceBannedWords(string content, char replacementCharacter = '#')
        {
            if (content == null)
            {
                return null;
            }

            if (content.Trim().Length == 0)
            {
                return content;
            }

            List<string> bannedWordList = _bannedWordRetrievalService.GetBannedWords()
                .Select(bannedWord => bannedWord.ToLower())
                .ToList();

            string lowercaseContent = content.ToLower();
            string resultContent = content;

            PhraseMatchResult currentResult = null;
            int currentIndex = 0;
            while ((currentResult = _matcher.Match(currentIndex, lowercaseContent, bannedWordList)) != null)
            {

                int replacedWordLength = currentResult.MatchedPhrase.Length;

                if (replacedWordLength <= 2)
                {
                    // Replace entire words less than or equal to two characters in length
                    resultContent = resultContent.Remove(currentResult.Index, replacedWordLength);

                    resultContent = resultContent.Insert(currentResult.Index, replacementCharacter + "");
                    if (replacedWordLength == 2)
                    {
                        resultContent = resultContent.Insert(currentResult.Index, replacementCharacter + "");
                    }

                }
                else
                {
                    // Replace the middle characters
                    resultContent = resultContent.Remove(currentResult.Index + 1, replacedWordLength - 2);
                    for (int i = 0; i < replacedWordLength - 2; i++)
                    {
                        resultContent = resultContent.Insert(currentResult.Index + 1, replacementCharacter + "");
                    }
                }

                // Update index
                currentIndex = currentResult.Index + currentResult.MatchedPhrase.Length;
            }

            return resultContent;
        }
    }
}

