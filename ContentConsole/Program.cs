using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {


            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

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
