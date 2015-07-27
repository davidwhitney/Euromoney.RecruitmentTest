using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public static class Variables
    {
        public static int choice;
        public static string _content;
        static public List<string> _bad_words_list;

        public static void SetContent(string content)
        {
            _content = content;
        }

        public static string GetContent()
        {
            string output_content = _content;
            if (choice == 2)
            {
                return output_content;
            }
            else if (choice == 3)
            {
                for (int i_word = 0; i_word <= _bad_words_list.Count - 1; i_word++)
                {
                    string new_bad_word = _bad_words_list[i_word].Substring(0, 1);
                    for (int i_letter = 1; i_letter <= _bad_words_list[i_word].Length - 2; i_letter++)
                    {
                        new_bad_word = new_bad_word + "#";
                    }
                    new_bad_word = new_bad_word + _bad_words_list[i_word].Substring(_bad_words_list[i_word].Length - 1, 1);
                    output_content = output_content.Replace(_bad_words_list[i_word], new_bad_word);
                }
            }
            return output_content;
        }

        public static void SetList(List<string> new_list)
        {
            _bad_words_list = new_list;
        }
        
         public static List<string> GetList()
        {
            return _bad_words_list;
        }
    }
}
