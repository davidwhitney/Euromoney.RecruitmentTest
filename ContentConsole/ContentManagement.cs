using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole
{

    public interface IContentManagement
    {
        List<BannedWord> BannedWordCounter(string text, string[] arrBannedWord);
        List<BannedWord> BannedWordCounter(string text, string bannedWord);
        string BannedWordReplacer(string text, string[] bannedWord);
    }

    //May be will need this interface without 'BannedWordReplacer' in future
    public interface IContentManagementNoReplacer
    {
        List<BannedWord> BannedWordCounter(string text, string[] arrBannedWord);
        List<BannedWord> BannedWordCounter(string text, string bannedWord);
    }

    public class ContentManagement : IContentManagement, IContentManagementNoReplacer
    {
        //Working with string ARRAY
        public List<BannedWord> BannedWordCounter(string text, string[] arrBannedWords)
        {
            return FillBannedWord(text, TrimArray(arrBannedWords));
        }
        //Working with regular string
        public List<BannedWord> BannedWordCounter(string text, string bannedWords)
        {
            return FillBannedWord(text, TrimArray(bannedWords));
        }
        private List<BannedWord> FillBannedWord(string text, string[] arrBannedWords)
        {
            var _bannedWord = new List<BannedWord>();

            foreach (string word in arrBannedWords)
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

        public string BannedWordReplacer(string text, string[] bannedWord)
        {
            bannedWord = TrimArray(bannedWord);
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

        private string[] TrimArray(string str)
        {
            string[] arrTemp = str.Split(',');
            return TrimArray(arrTemp);
        }
        private string[] TrimArray(string[] arr)
        {
            List<string> listTemp = new List<string>();
            foreach (string s in arr)
            {
                var temp = s.Trim().ToLower();
                if (temp != "")
                    listTemp.Add(temp);
            }
            listTemp.Sort();
            //Remove duplicate (is exist)
            listTemp = listTemp.Distinct().ToList();

            return listTemp.ToArray();
        }

    }
}
