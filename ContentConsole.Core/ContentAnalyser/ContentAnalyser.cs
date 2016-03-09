using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public class ContentAnalyser : IContentAnalyser
    {
        public string Content { get; set; }

        private IWordFilter _filter;
        private IWordCounter _counter;
        private IDataStore<string> _dataStore;

        public ContentAnalyser(IDataStore<string> dataStore, IWordCounter counter, IWordFilter filter)
        {
            Content = string.Empty;
            _dataStore = dataStore;
            _counter = counter;
            _filter = filter;
        }

        public int CountNegativeWords()
        {
            return _counter.Count(Content, _dataStore.GetAll());
        }

        public string FilterNegativeWords()
        {
            return _filter.Filter(Content, _dataStore.GetAll());
        }

        public void EnableFilter()
        {
            _filter.Enabled = true;
        }

        public void DisableFilter()
        {
            _filter.Enabled = false;
        }

        public void AddNegativeWord(string word)
        {
            _dataStore.Add(word);
        }

        public void DeleteNegativeWord(string word)
        {
            _dataStore.Delete(word);
        }

        public IEnumerable<string> GetNegativeWords()
        {
            return _dataStore.GetAll();
        }

        public void DeleteAllNegativeWords()
        {
            _dataStore.DeleteAll();
        }
    }
}
