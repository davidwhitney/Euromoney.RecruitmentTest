using System.Collections.Generic;

namespace ContentConsole
{
    public interface IContentRules
    {
        IEnumerable<string> NegativeWords { get; set; }
    }
}