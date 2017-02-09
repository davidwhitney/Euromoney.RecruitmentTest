using System;
using ContentConsole.DataRepository;
using ContentConsole.Helpers;
using ContentConsole.Services;

namespace ContentConsole
{
    public static class Program
    {
        // Settings
        private const string BannedWordFileLocation = "../../BannedWordFile.txt";
        private const bool HideBannedWords = true;

        public static void Main(string[] args)
        {

            // Load words from file 
            IBannedWordRepository bannedWordRepository = new BannedWordFileRepository(BannedWordFileLocation);

            IBannedWordRetrievalService bannedWordRetrieval = new BannedWordRetrievalService(bannedWordRepository);
            IBannedWordCounterService bannedWordCounterService = new BannedWordCounterService(bannedWordRetrieval, new PhraseMatcher());

            IBannedWordReplacementService bannedWordReplacementService
                = new BannedWordReplacementService(bannedWordRetrieval, new PhraseMatcher());

            // Calculations 
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            int bannedWordCount = bannedWordCounterService.CountBannedWords(content);

            // Display output 
            Console.WriteLine("Scanned the text:");

            // Conditionally hide the banned words
            if (HideBannedWords)
            {
                Console.WriteLine(bannedWordReplacementService.ReplaceBannedWords(content));
            }
            else
            {
                Console.WriteLine(content);
            }

            Console.WriteLine("Total Number of negative words: " + bannedWordCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
