using ContentConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegativeWordUnitTest
{
    public class TestNegativeWordCheck: NegativeWordCheck
    {
        public List<string> NegativeWords { get; set; }

        public override List<string> GetNegativeWords(List<string> negativeWords)
        {
            if (this.NegativeWords == null)
            {
                negativeWords = new List<string>()
                {
                    "swine",
                    "bad",
                    "nasty",
                    "horrible",
                 };
            }

            return negativeWords;
        }
    }
}
