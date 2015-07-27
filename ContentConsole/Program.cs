using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BadWords bw = new BadWords();
            bw.GetBadWords();

            re_try:
            try
            {
                Console.WriteLine("Please input 1 for Bad Word Admin, 2 for Content Curator, or 3 for Reader:");
                Variables.choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid choice, please retry.");
                goto re_try;
            }
            

            if (Variables.choice == 1) //Admin
            {
                Console.WriteLine("Current bad words are:");

                List<string> bad_words_list = Variables.GetList();

                for (int i_bad_words = 0; i_bad_words <= bad_words_list.Count - 1; i_bad_words++)
                {
                    Console.WriteLine(bad_words_list[i_bad_words]);
                }

                AddWord aw = new AddWord();
                aw.NewWord();

                Console.WriteLine("Press ANY key.");
                Console.ReadKey();
            }

            else  //Curator & Reader
            {
                GetContent gc = new GetContent();
                gc.NewContent();

                Console.WriteLine();
                Console.WriteLine("Scanned the text:");
                Console.WriteLine(Variables.GetContent());
                Console.WriteLine("Total Number of negative words: " + ContentScanner.BadWordCount());

                Console.WriteLine("Press ANY key to exit.");
                Console.ReadKey();
            }

        }
    }
}
