using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class BannedWords : IBannedWords
    {
        private ITempFileProvider _tempFileProvider;
        public BannedWords(ITempFileProvider tempFileProvider)
        {
            _tempFileProvider = tempFileProvider;
            _bannedWords = new List<string>();
            LoadContent();
        }

        private void LoadContent()
        {
            var content = _tempFileProvider.ReadContent();
            _bannedWords.AddRange(content.Split(','));
        }
        private void SaveContent()
        {
            var content = string.Join(",", _bannedWords);
            _tempFileProvider.SetContent(content);
        }

        private static List<string> _bannedWords;
        public IEnumerable<string> List
        {
            get
            {
                return _bannedWords;
            }
        }

        public void AddWord(string word)
        {
            if(!_bannedWords.Contains(word))
            {
                _bannedWords.Add(word);
            }
            SaveContent();
        }

        public void RemoveWord(string word)
        {
            if(_bannedWords.Contains(word))
            {
                _bannedWords.Remove(word);
            }
            SaveContent();
        }
    }
}
