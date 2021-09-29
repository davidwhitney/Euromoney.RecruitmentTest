using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentConsole
{
    public class BannedWordDictionary : IBannedWordDictionary
    {
        List<string> bannedWords = new List<string>() { "swine", "bad", "nasty", "horrible" };
        public List<string> GetBannedWords() => bannedWords;

        public void AddWord(string input) => bannedWords.Add(input);

        public void DeleteWord(string input) => bannedWords.Remove(input);

    }
}
