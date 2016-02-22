using System.Collections.Generic;

namespace ContentConsole.DAL.Repositories
{
    public class ContentRulesRepository : IContentRulesRepository
    {
        private readonly IContentRulesContext _context;

        public ContentRulesRepository(IContentRulesContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetNegativeWords()
        {
            //Stub here instead of using context
            var stubbedData = new List<string>()
            {
                "bad",
                "horrible"
            };

            return stubbedData;
        }
    }
}