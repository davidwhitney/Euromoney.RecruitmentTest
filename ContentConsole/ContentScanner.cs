using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public static class ContentScanner
    {
        public static int BadWordCount()
        {
            int qty_bad_words = 0;
            List<string> bad_words_list = Variables.GetList();

            for (int i_bad_words = 0; i_bad_words <= bad_words_list.Count - 1; i_bad_words++)
            {
                if (Variables.GetContent().Contains(bad_words_list[i_bad_words]))
                {
                    qty_bad_words++;
                }
            }
            return qty_bad_words;
        }
    }
}
