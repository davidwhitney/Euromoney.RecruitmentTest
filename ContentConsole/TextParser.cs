using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class TextParser
    {
        private readonly IBannedWords _bannedWords;
        public TextParser(IBannedWords bannedWords)
        {
            _bannedWords = bannedWords;
        }
        
        public int CountBadWords(string content)
        {
            int badWords = 0;
            foreach (var bannedWord in _bannedWords.List)
            {
                badWords += Regex.Matches(content, bannedWord).Count;
            }
            return badWords;
        }
    }
}
