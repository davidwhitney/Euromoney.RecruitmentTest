using ContentConsole.Interfaces;
using ContentConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole.BusinessManager
{
    public class ContentModerator: IContentModerator
    {
        public int CountNegativeWords(List<string> negativeWords, string content)
        {
            int wordCount=0;
           
            foreach (var word in negativeWords)
            {
                wordCount += new Regex(Regex.Escape(word)).Matches(content).Count;           
            }

            return wordCount;
        }

        public string ReplaceWords(List<HashedWord> negativeHashedWords, string content)
        {
            StringBuilder sb = new StringBuilder(content);
            foreach (var hashedword in negativeHashedWords)
            {
                sb=sb.Replace(hashedword.bannedword, hashedword.Hashedword);
            }

            return sb.ToString();
        }
        public List<HashedWord> HashWords(List<string> negativeWords)
        {
            var negativeHashedWords = new List<HashedWord>();
            var sb = new StringBuilder();
            foreach (var word in negativeWords)
            {
                sb.Clear();
                sb.Append(word[0]);
                for (int i=1;i< word.Length-1;i++)
                {
                    sb.Append("#");
                }
                sb.Append(word[word.Length - 1]);
                negativeHashedWords.Add(new HashedWord { bannedword = word, Hashedword = sb.ToString() });
            }

            return negativeHashedWords;
        }
    }
}
