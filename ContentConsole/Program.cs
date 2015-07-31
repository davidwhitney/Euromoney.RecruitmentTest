using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            List<string> Badwords = new List<string>();
            Badwords.Add(bannedWord1);
            Badwords.Add(bannedWord2);
            Badwords.Add(bannedWord3);
            Badwords.Add(bannedWord4);

            int wordcount = 0;
            string Filteredstring = "";
            int option = 0;
            Console.Write("\nPlease enter the option");
            Console.Write("\nPlease enter 1 for RUN mode:");
            Console.Write("\nPlease enter 2 for TEST mode:");
            int mode = int.Parse(Console.ReadLine());
            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            Console.WriteLine();
            UserFilter uf = new UserFilter();
            UnitTest ut = new UnitTest();
            if (mode == 1)
            {

                do
                {

                    Console.Write("\n\nEnter the Option: \n1. User \n2. Administrator \n3. Reader\n4. Content Curator\n5. Exit\n");
                    option = int.Parse(Console.ReadLine());


                    switch (option)
                    {
                        case 1:
                            wordcount = uf.BadwordsCount(content, Badwords);
                            Console.WriteLine("\nTotal Number of Negative words: {0} ", wordcount);
                            break;

                        case 2:
                            Console.Write("Enter the option: \n1.Add item \n2.Remove item \n3.Display\n");
                            int option1 = int.Parse(Console.ReadLine());
                            switch (option1)
                            {
                                case 1: uf.AddBadword(Badwords);
                                    break;
                                case 2: uf.RemoveBadword(Badwords);
                                    break;
                                case 3: uf.DisplayBadword(Badwords);
                                    break;
                                default:
                                    break;
                            }
                            break;

                        case 3:
                            Filteredstring = uf.ChangeBadword(Badwords, content);
                            Console.WriteLine("\nFiltered Content: \n" + Filteredstring);
                            break;

                        case 4:
                            uf.BadwordsCount(content, Badwords);
                            break;

                        case 5:
                            break;

                        default:
                            break;


                    }
                } while (option != 5);

            }

            else if (mode == 2)
            {

                ut.BadwordcountTest1();
                ut.BadwordcountTest2();
                ut.AddBadwordTest();
                ut.RemoveBadwordTest();
                ut.ChangeBadwordTest1();
                ut.ChangeBadwordTest2();
            }

            else
            {
                Console.WriteLine("\nInvalid option");
            
           }

            Console.WriteLine("\nPress ANY key to exit.");
            Console.ReadKey();


        }

       
        }

    class UserFilter
    {
        /* story 1 */
        public int BadwordsCount(string content, List<string> list)
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


    class UnitTest
    {
        private UserFilter uf;
        public UnitTest()
        {
            uf = new UserFilter();
        }        
        public void BadwordcountTest1()
       {
            Console.Write("\n\nTest 1\n");                    
            int expectedcount = 2;
            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            List<string> Badwords = new List<string>(){"swine","bad","nasty","horrible"};

            
            int obtainedcount=uf.BadwordsCount(content,Badwords);
            if (obtainedcount == expectedcount)
            {
                Console.Write("\nTest 1: BadwordcountTest1 Passed");
            }
            else
            {
                Console.Write("\nTest 1: BadwordcountTest1 Failed");
            }                       
        }
        public void BadwordcountTest2()
        {
            Console.Write("\n\nTest 2\n");                    
            int expectedcount = 5;
            string content = "The bad weather in bad Manchester in bad winter is bad. It rains all the time - it must be horrible for people visiting.";
            List<string> Badwords = new List<string>() { "swine", "bad", "nasty", "horrible" };


            int obtainedcount = uf.BadwordsCount(content, Badwords);
            if (obtainedcount == expectedcount)
            {
                Console.Write("\nTest 2: BadwordcountTest2 Passed");
            }
            else
            {
                Console.Write("\nTest 2: BadwordcountTest2 Failed");
            }
        }
        public void AddBadwordTest()
        {
            Console.Write("\n\nTest 3\n");                    
            List<string> Badwords = new List<string>() { "swine", "bad", "nasty", "horrible" };
            List<string> expectedlist = new List<string>() { "swine", "bad", "nasty", "horrible", "worst" };
            Console.Write("\nPlease enter 'worst' as the new word for testing purpose");
            uf.AddBadword(Badwords);
            if (Badwords.Last() == expectedlist.Last())
            {
                Console.Write("\nTest 3:AddBadwordTest Passed");
            }
            else
            {
                Console.Write("\nTest 3: AddBadwordTest Failed");
            }
        }
        public void RemoveBadwordTest()
        {
            Console.Write("\n\nTest 4\n");                    
            List<string> obtainedlist = new List<string>() { "swine", "bad", "nasty", "horrible" };
            List<string> expectedlist = new List<string>() { "swine", "bad", "nasty"};
            Console.Write("\nPlease enter 'horrible' for testing purpose");
            uf.RemoveBadword(obtainedlist);
            if (obtainedlist.Last() == expectedlist.Last())
            {
                Console.Write("\nTest 4: RemoveBadwordTest Passed");
            }
            else
            {
                Console.Write("\nTest 4: RemoveBadwordTest Failed");
            }
        }
        public void ChangeBadwordTest1()
        {
            Console.Write("\n\nTest 5\n");                    
            List<string> Badwords = new List<string>() { "swine", "bad", "nasty", "horrible" };
            string original = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string expected = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
            string Obtained = uf.ChangeBadword(Badwords,original);
            if (Obtained == expected)
            {
                Console.Write("\nTest 5: ChangeBadwordTest1 Passed");
            }
            else
            {
                Console.Write("\nTest 5: ChangeBadwordTest1 Failed");
            }
        }
        public void ChangeBadwordTest2()
        {
            Console.Write("\n\nTest 6\n");                    
            List<string> Badwords = new List<string>() { "swine", "bad", "nasty", "horrible" };            
            string original = "The bad weather in bad Manchester in bad winter is bad. It rains all the time - it must be horrible for people visiting.";
            string expected = "The b#d weather in b#d Manchester in b#d winter is b#d. It rains all the time - it must be h######e for people visiting.";            
            string Obtained = uf.ChangeBadword(Badwords, original);
            if (Obtained == expected)
            {
                Console.Write("\nTest 6: ChangeBadwordTest2 Passed");
            }
            else
            {
                Console.Write("\nTest 6: ChangeBadwordTest2 Failed");
            }

        }
    }
    
}
