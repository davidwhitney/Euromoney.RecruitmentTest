using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentConsole
{
    public class BadWord
    {
        public BadWord()
        {

        }

        public BadWord(string word)
        {
            Text = word;
        }

        public string Text { get; set; }
    }
}
