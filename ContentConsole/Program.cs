using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nPlease enter phrase to check over");
            var text = Console.ReadLine();
            Console.WriteLine("Please press Y to disable filtering of negative words or press Enter to continue");

            var enableFiltering = !Console.ReadKey().Key.Equals(ConsoleKey.Y);
            var negativeWordCheck = new NegativeWordCheck();

            var result = negativeWordCheck.RunNegativeWordCheck(text, enableFiltering);

            Console.WriteLine("Scanned the Text: \n" + result.Phrase + "\nTotal Number of negative words: " + result.NegativeWordCount);
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
