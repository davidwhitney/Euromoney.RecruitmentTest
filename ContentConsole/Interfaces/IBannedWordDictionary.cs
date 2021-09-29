using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Interfaces
{
    public interface IBannedWordDictionary
    {
        public List<string> GetBannedWords();
        public void AddWord(string newWord);
        public void DeleteWord(string wordToDelete);
    }
}
