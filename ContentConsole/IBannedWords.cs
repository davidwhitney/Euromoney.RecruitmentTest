using System.Collections.Generic;

namespace ContentConsole
{
    public interface IBannedWords
    {
        IEnumerable<string> List { get; }
    }
}