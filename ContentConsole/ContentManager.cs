using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class ContentManager
    {
        public readonly TextAnalyser TextAnalyser;
        private readonly String text;

        public ContentManager(TextAnalyser textAnalyser, string text)
        {
            this.TextAnalyser = textAnalyser;
            this.text = text;
        }

        public string ScanText()
        {
            int numberOfNegativeWords = TextAnalyser.Analyse(text);
            return String.Format("Scanned the text:{0}{1}{0}Total Number of negative words: {2}",
                Environment.NewLine, text, numberOfNegativeWords);
        }

        public string ReadText(bool filter = true)
        {
            if (filter)
                return TextAnalyser.Filter(text);
            else
                return text;
        }
    }
}
