using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            INegativeWordsFilteration negativeWordsFilteration = new NegativeWordsFilteration();
            negativeWordsFilteration.AddNegativeWords("swine");
            negativeWordsFilteration.AddNegativeWords("bad");
            negativeWordsFilteration.AddNegativeWords("nasty");
            negativeWordsFilteration.AddNegativeWords("horrible");
            negativeWordsFilteration.AddNegativeWords("irritated");

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting. Some people feels irritated with this.";

            
            int count = negativeWordsFilteration.NegativeWordCount(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + count);

            negativeWordsFilteration.RemoveNegativeWords("horrible");
            int count1 = negativeWordsFilteration.NegativeWordCount(content);

            Console.WriteLine("After removing negative word from data store :");
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + count1);

            string contentWithoutBadWords = negativeWordsFilteration.FilterNegativeWords(content,isEnable:true);

            Console.WriteLine("The content without bad words : ");
            Console.WriteLine(contentWithoutBadWords);

            string contentWithBadWords = negativeWordsFilteration.FilterNegativeWords(content, isEnable: false);

            Console.WriteLine("The content with bad words : ");
            Console.WriteLine(contentWithBadWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

    }

}
