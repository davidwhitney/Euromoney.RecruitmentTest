using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ContentConsole.DAL.Repositories;

namespace ContentConsole
{
    public class ContentParser : IContentParser
    {
        private readonly IContentRulesRepository _contentRulesRepository;
        private IEnumerable<string> _negativeWords; 

        public ContentParser(IContentRulesRepository contentRulesRepositoryRepository)
        {            
            _contentRulesRepository = contentRulesRepositoryRepository;
            _negativeWords = _contentRulesRepository.GetNegativeWords();
        }

        public int CountNegativeWords(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;             

            return _negativeWords.Count(input.Contains);
        }

        public string FilterNegativeWordsIfEnabled(string input, bool shouldFilter) //TODO Refactor to remove flag
        {
            if (shouldFilter)
            {
                var regexString = BuildNegativeWordsRegularExpressions();

                return Regex.Replace(input, regexString, ReplaceMiddleCharacters());                
            }

            return input;
        }

        private string BuildNegativeWordsRegularExpressions()
        {
            return string.Join("|", _negativeWords);
        }

        private MatchEvaluator ReplaceMiddleCharacters()
        {
            return delegate(Match match)
            {
                var matchedString = match.ToString();
                var stringArray = matchedString.ToCharArray();
                for (var i = 1; i < matchedString.Length - 1; i++)
                {
                    stringArray[i] = '#';
                }

                return string.Join("", stringArray);
            };
        }
    }
}