using System.Collections.Generic;

namespace ContentConsole.DAL.Repositories
{
    public interface IContentRulesRepository
    {
        IEnumerable<string> GetNegativeWords();
    }
}