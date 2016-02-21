using System.Collections.Generic;

namespace ContentConsole
{
    public class ContentRules : IContentRules
    {
        private IEnumerable<string> _negativeWordsList = new List<string>()
        {
            "swine",
            "bad",
            "nasty",
            "horrible"
        };

        public IEnumerable<string> NegativeWords
        {
            get { return _negativeWordsList; }
            set { _negativeWordsList = value; }
        }
    }
}