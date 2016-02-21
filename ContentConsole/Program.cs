using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            
            //Move to IoC
            var contentRules = new ContentRules();

            var contentParser = new ContentParser(contentRules);

            var badWordCount = contentParser.CountNegativeWords(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWordCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
