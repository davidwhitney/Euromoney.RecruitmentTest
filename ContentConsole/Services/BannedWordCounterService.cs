using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.DataRepository;
using ContentConsole.Helpers;

namespace ContentConsole.Services
{
    /// <summary>
    /// A service which counts the number of instances of banned words
    /// </summary>
    public class BannedWordCounterService : IBannedWordCounterService
    {
        private readonly IBannedWordRetrievalService _bannedWordRetrievalService;
        private readonly IPhraseMatcher _matcher;
        public BannedWordCounterService(IBannedWordRetrievalService bannedWordRetrievalService, IPhraseMatcher matcher)
        {
            _bannedWordRetrievalService = bannedWordRetrievalService;
            _matcher = matcher;
        }

        /// <summary>
        /// Counts the banned words in the content
        /// </summary>
        /// <param name="content">The content to process</param>
        /// <returns>Number of banned words found</returns>
        public int CountBannedWords(string content)
        {
            // Use the matcher to iterate through the words to find matches
            string lowercaseContent = content.ToLower();

            List<string> bannedWordList = _bannedWordRetrievalService.GetBannedWords()
                .Select(bannedWord => bannedWord.ToLower())
                .ToList();

            PhraseMatchResult currentResult = null;
            int currentIndex = 0;
            int count = 0;
            while ((currentResult = _matcher.Match(currentIndex, lowercaseContent, bannedWordList)) != null)
            {
                count++;
                // Update index
                currentIndex = currentResult.Index + currentResult.MatchedPhrase.Length;
            }

            return count;
        }
    }
}
