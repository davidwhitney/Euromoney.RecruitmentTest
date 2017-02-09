using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Helpers
{
    /// <summary>
    /// Store the result of the PhraseMatcher, the matched phrase and it's location. 
    /// </summary>
    public class PhraseMatchResult
    {
        public int Index { get; set; }
        public string MatchedPhrase { get; set; }
    }
}
