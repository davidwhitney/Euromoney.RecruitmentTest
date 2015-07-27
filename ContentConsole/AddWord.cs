using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    class AddWord
    {
        public string new_word;
        
        public void NewWord()
        {
            Console.WriteLine("Enter new bad word: ");
            new_word = Console.ReadLine();
            BadWords bs = new BadWords();
            bs.AddBadWord(new_word);
        }
    }
}
