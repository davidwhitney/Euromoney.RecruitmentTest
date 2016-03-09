using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public class WordFilter : IWordFilter
    {
        public bool Enabled { get; set; }

        public WordFilter()
        {
            Enabled = true;
        }

        public string Filter(string text, IEnumerable<string> words)
        {
            if (!Enabled)
            {
                return text;
            }

            foreach (var word in words)
            {
                var pattern = $@"\b({word})\b"; // match whole words only
                // We can't replace directly with the censored version, since the censored case must match the original case
                var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).OfType<Match>();
                foreach (var match in matches)
                {
                    var censored = CensorWord(match.Value);
                    text = ReplaceAtIndex(text, match.Index, censored);
                }
            }

            return text;
        }

        private string CensorWord(string word)
        {
            switch (word.Length)
            {
                case 1:
                    return "#";
                case 2:
                    return "##";
                default:
                    return CensorLongWord(word);
            }
        }

        private string CensorLongWord(string word)
        {
            var sb = new StringBuilder();
            sb.Append(word[0]);
            for (int i = 1; i < word.Length - 1; i++)
            {
                sb.Append('#');
            }
            sb.Append(word[word.Length - 1]);
            return sb.ToString();
        }

        private string ReplaceAtIndex(string str, int index, string replacement)
        {
            return str.Remove(index, replacement.Length).Insert(index, replacement);
        }
    }
}
