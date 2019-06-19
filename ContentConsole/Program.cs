using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter content:");
            var content = Console.ReadLine();

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
