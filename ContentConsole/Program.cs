using System;
using ContentConsole.DAL;
using ContentConsole.DAL.Repositories;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            
            //Move to IoC container
            var dbContext = new ContentRulesContext();
            var contentRulesRepository = new ContentRulesRepository(dbContext);
            var contentParser = new ContentParser(contentRulesRepository);

            var badWordCount = contentParser.CountNegativeWords(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWordCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
