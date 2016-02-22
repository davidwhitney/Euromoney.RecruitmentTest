using System;
using ContentConsole.DAL;
using ContentConsole.DAL.Repositories;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {            
            //Move to IoC container
            var dbContext = new ContentRulesContext();
            var contentRulesRepository = new ContentRulesRepository(dbContext);
            var contentParser = new ContentParser(contentRulesRepository);
            var contentRetriever = new ContentRetriever();
            var content = contentRetriever.GetContent();

            var badWordCount = contentParser.CountNegativeWords(content);
            var disableFilter = Console.ReadLine();

            var shouldFilter = disableFilter != "y";

            var parsedContent = contentParser.FilterNegativeWordsIfEnabled(content, shouldFilter);

            Console.WriteLine("Enter 'y' to disable content filtering, otherwise press 'Enter' to proceed");

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(parsedContent);
            Console.WriteLine("Total Number of negative words: " + badWordCount);
            Console.WriteLine();
            Console.WriteLine("Press 'Return' to exit application.");
            Console.Read();
        }
    }
}
