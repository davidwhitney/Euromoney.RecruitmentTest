using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentConsole
{
    class UnitTest
    {
        private UserFilter FilterTest;
        public UnitTest()
        {
            FilterTest = new UserFilter();
        }
        public void BadwordCountTest1()
        {
            Console.Write("\n\nTest 1\n");
            int ExpectedCount = 2;
            string Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            List<string> BannedWords = new List<string>() { "swine", "bad", "nasty", "horrible" };

            int ObtainedCount = FilterTest.BannedWordCount(Content, BannedWords);
            if (ObtainedCount == ExpectedCount)
            {
                Console.Write("\nTest 1: BadwordCountTest1 Passed");
            }
            else
            {
                Console.Write("\nTest 1: BadwordCountTest1 Failed");
            }
        }
        public void BadwordCountTest2()
        {
            Console.Write("\n\nTest 2\n");
            int ExpectedCount = 5;
            string Content = "The bad weather in bad Manchester in bad winter is bad. It rains all the time - it must be horrible for people visiting.";
            List<string> BannedWords = new List<string>() { "swine", "bad", "nasty", "horrible" };


            int ObtainedCount = FilterTest.BannedWordCount(Content, BannedWords);
            if (ObtainedCount == ExpectedCount)
            {
                Console.Write("\nTest 2: BadwordCountTest2 Passed");
            }
            else
            {
                Console.Write("\nTest 2: BadwordCountTest2 Failed");
            }
        }
        public void AddBadwordTest()
        {
            Console.Write("\n\nTest 3\n");
            List<string> BannedWords = new List<string>() { "swine", "bad", "nasty", "horrible" };
            List<string> ExpectedList = new List<string>() { "swine", "bad", "nasty", "horrible", "worst" };
            Console.Write("\nPlease enter 'worst' as the new word for testing purpose");
            FilterTest.AddBadword(BannedWords);
            if (BannedWords.Last() == ExpectedList.Last())
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
            List<string> ObtainedList = new List<string>() { "swine", "bad", "nasty", "horrible" };
            List<string> ExpectedList = new List<string>() { "swine", "bad", "nasty" };
            Console.Write("\nPlease enter 'horrible' for testing purpose");
            FilterTest.RemoveBadword(ObtainedList);
            if (ObtainedList.Last() == ExpectedList.Last())
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
            List<string> BannedWords = new List<string>() { "swine", "bad", "nasty", "horrible" };
            string Original = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string Expected = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
            string Obtained = FilterTest.ChangeBadword(BannedWords, Original);
            if (Obtained == Expected)
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
            List<string> BannedWords = new List<string>() { "swine", "bad", "nasty", "horrible" };
            string Original = "The bad weather in bad Manchester in bad winter is bad. It rains all the time - it must be horrible for people visiting.";
            string Expected = "The b#d weather in b#d Manchester in b#d winter is b#d. It rains all the time - it must be h######e for people visiting.";
            string Obtained = FilterTest.ChangeBadword(BannedWords, Original);
            if (Obtained == Expected)
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
