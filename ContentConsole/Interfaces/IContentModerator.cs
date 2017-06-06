using ContentConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Interfaces
{
    public interface IContentModerator
    {
        int CountNegativeWords(List<string> negativeWords, string content);
        string ReplaceWords(List<HashedWord> negativeWords, string content);
        List<HashedWord> HashWords(List<string> negativeWords);
    }
}
