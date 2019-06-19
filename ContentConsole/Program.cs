using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter content:");
            var content = Console.ReadLine();

            // In real life I would use a dependency injector rather than instantiating the parser and in dependents here.
            var badWordRepository = new InMemoryBadWordRepository();
            var badWordParser = new BadWordParser(badWordRepository);

            var parseReponse = badWordParser.Parse(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(parseReponse.Content);
            Console.WriteLine("Total Number of negative words: " + parseReponse.BadWordCount);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
