using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class ContentManagement
    {

        public List<BannedWord> BannedWordCounter(string text, string[] arrBannedWord)
        {
            var _bannedWord = new List<BannedWord>();

            foreach (string word in arrBannedWord)
            {
                if (word.Trim() != "")
                {
                    var cleanedtext = text.ToUpper().Replace(word.ToUpper(), "");
                    var cnt = (text.Length - cleanedtext.Length) / word.Length;
                    if (cnt > 0)
                    {
                        _bannedWord.Add(new BannedWord()
                        {
                            Word = word,
                            Count = cnt
                        });
                    }
                }
            }

            return _bannedWord;
        }
        public List<BannedWord> BannedWordCounter(string text, string bannedWord)
        {
            var _bannedWord = new List<BannedWord>();
            bannedWord = bannedWord.Replace(" ", "");
            string[] arrBannedWords = bannedWord.Split(',');

            foreach (string word in arrBannedWords)
            {
                if(word.Trim() != "")
                {
                    var cleanedtext = text.ToUpper().Replace(word.ToUpper(), "");
                    var cnt = (text.Length - cleanedtext.Length) / word.Length;
                    if (cnt > 0)
                    {
                        _bannedWord.Add(new BannedWord()
                        {
                            Word = word,
                            Count = cnt
                        });
                    }
                }
            }

            return _bannedWord;
        }


        public string BannedWordReplacer(string text, string[] bannedWord)
        {
            foreach (string word in bannedWord)
            {
                if (word.Trim() != "")
                {
                    var temp = HashedString(word);
                    text = Regex.Replace(text, word, @temp, RegexOptions.IgnoreCase);
                }
            }

            return text;
        }


        private string HashedString(string str)
        {
            var hash = "";
            var first = "";

            for (int i = 0; i < str.Length - 2; i++)
            {
                if (i == 0)
                    first = str.Substring(i, 1);
                else if (first.Trim() == "")
                {
                    first = " " + str.Substring(i, 1);
                    i ++;
                }
                    
                
                hash += "#";
            }

            return first + hash + str.Substring(str.Length - 1, 1);
        }

    }
}
