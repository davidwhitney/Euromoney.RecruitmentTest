using System.Linq;

namespace ContentConsole
{
    public class ContentParser : IContentParser
    {
        private readonly IContentRules _contentRules;

        public ContentParser(IContentRules contentRules)
        {            
            _contentRules = contentRules;
        }

        public int CountNegativeWords(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return _contentRules.NegativeWords.Count(input.Contains);
        }
    }
}