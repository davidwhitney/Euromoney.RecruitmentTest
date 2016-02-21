using System.Linq;
using ContentConsole.DAL.Repositories;

namespace ContentConsole
{
    public class ContentParser : IContentParser
    {
        private readonly IContentRulesRepository _contentRulesRepository;

        public ContentParser(IContentRulesRepository contentRulesRepositoryRepository)
        {            
            _contentRulesRepository = contentRulesRepositoryRepository;
        }

        public int CountNegativeWords(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var negativeWordsList = _contentRulesRepository.GetNegativeWords();

            return negativeWordsList.Count(input.Contains);
        }
    }
}