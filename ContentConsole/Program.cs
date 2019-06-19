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
            var badWordParser = new BadWordService(badWordRepository);

            var badWords = badWordParser.GetBadWordCount(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
