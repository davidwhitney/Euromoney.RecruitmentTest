using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentConsole
{
    class UserFilter
    {
        
            /* story 1 */
            public int BannedWordCount(string content, List<string> list)
            {
                Console.Write("\nScanned the Text:\n" + content + "\n");
                int i = 0;
                int count = 0;
                foreach (string word in list)
                {
                    i = 0;
                    while ((i = content.IndexOf(word, i)) != -1)
                    {
                        i += word.Length;
                        count++;
                    }
                }
                return count;
            }

            /* Story2 */
            public void AddBadword(List<string> list)
            {
                Console.Write("\nEnter a word to add to the badword list:");
                string addword = Console.ReadLine();
                list.Add(addword);
                DisplayBadword(list);
            }

            public void RemoveBadword(List<string> list)
            {
                Console.Write("\nEnter a word to remove from the badword list:");
                string removeword = Console.ReadLine();
                list.Remove(removeword);
                DisplayBadword(list);
            }

            public void DisplayBadword(List<string> list)
            {
                foreach (string removebadword in list)
                {
                    Console.WriteLine(removebadword);
                }
                Console.WriteLine();
            }


            /* Story3 */
            public string ChangeBadword(List<string> list, string content)
            {
                char[] contentchar = content.ToCharArray();
                foreach (string words in list)
                {
                    int badwordindex = 0;
                    //int badwordindex = content.IndexOf(words); //Old
                    while ((badwordindex = content.IndexOf(words, badwordindex)) != -1) //New

                        if (badwordindex != -1)
                        {
                            for (int j = 1; j < words.Length - 1; j++)
                            {
                                badwordindex++;
                                contentchar[badwordindex] = '#';
                            }
                        }
                }
                string Filteredstring = new string(contentchar);
                return Filteredstring;
            
        }
    }
}
