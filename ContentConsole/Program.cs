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

            List<string> BannedWords = new List<string>();
            BannedWords.Add(bannedWord1);
            BannedWords.Add(bannedWord2);
            BannedWords.Add(bannedWord3);
            BannedWords.Add(bannedWord4);

            int WordCount = 0;
            string FilteredString = "";
            int Option = 0;
            
            Console.Write("Please enter the Option");            
            Console.Write("\n1. RUN Mode\n2. TEST Mode\n");
            int Mode = int.Parse(Console.ReadLine());
            string Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.\n";

            UserFilter Filter = new UserFilter();
            UnitTest Tester = new UnitTest();

            /*execution under RUN Mode*/
            if (Mode == 1)
            {
                do
                {
                    Console.Write("\n\nEnter the Option: \n1. User \n2. Administrator \n3. Reader\n4. Content Curator\n5. Exit\n");
                    Option = int.Parse(Console.ReadLine());
                    switch (Option)
                    {

                        /* Story 1: As a user */ 
                        case 1:
                            WordCount = Filter.BannedWordCount(Content, BannedWords);
                            Console.WriteLine("\nTotal Number of Negative words: {0} ", WordCount);
                            break;

                        /*Story 2: As an administrator */ 
                        case 2:
                            Console.Write("Enter the Option: \n1.Add item \n2.Remove item \n3.Display\n");
                            int option1 = int.Parse(Console.ReadLine());
                            switch (option1)
                            {
                                    /*To Add new words*/
                                case 1: Filter.AddBadword(BannedWords);
                                    break;

                                    /*To Remove words*/
                                case 2: Filter.RemoveBadword(BannedWords);
                                    break;

                                    /*To Display words*/
                                case 3: Filter.DisplayBadword(BannedWords);
                                    break;

                                default:
                                    break;
                            }
                            break;

                        /* Story 3: As a Reader */
                        case 3:
                            FilteredString = Filter.ChangeBadword(BannedWords, Content);
                            Console.WriteLine("\nFiltered Content: \n" + FilteredString);
                            break;

                        /* Story 3: As a content curator */
                        case 4:
                            WordCount = Filter.BannedWordCount(Content, BannedWords);
                            Console.WriteLine("\nTotal Number of Negative words: {0} ", WordCount);
                            break;

                        case 5:
                            break;

                        default:
                            break;
                    }
                } while (Option != 5);
            }

            /*execution under TEST Mode*/
            else if (Mode == 2)
            {
                /*Badword count using original content*/
                Tester.BadwordCountTest1();

                /*Badword count for same word appearing multiple times*/
                Tester.BadwordCountTest2();

                /*To test addition of new bannedwords in the list*/
                Tester.AddBadwordTest();

                /*To test deletion of new bannedwords in the list*/
                Tester.RemoveBadwordTest();

                /*To test if middle letters are changed by # in original content*/
                Tester.ChangeBadwordTest1();

                /*To test if middle letters are changed by # when same word appears multiple times*/
                Tester.ChangeBadwordTest2();
            }
            else
            {
                Console.WriteLine("\nInvalid Option");
            }
            Console.WriteLine("\nPress ANY key to exit.");
            Console.ReadKey();
        }
    }
}
