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
        private List<string> _bannedWords = new List<string>
        {
            "swine",
            "bad",
            "nasty",
            "horrible"
        };
        public int CountBadWords(string content)
        {
            int badWords = 0;
            foreach (var bannedWord in _bannedWords)
            {
                badWords += Regex.Matches(content, bannedWord).Count;
            }
            return badWords;
        }
    }
}
