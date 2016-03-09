using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public class WordCounter : IWordCounter
    {
        public int Count(string text, IEnumerable<string> words)
        {
            var count = 0;
            foreach (var word in words)
            {
                var pattern = $@"\b({word})\b"; // match whole words only
                count += Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
            }
            return count;
        }
    }
}
