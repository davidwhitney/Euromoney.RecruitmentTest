using System;

namespace ContentConsole
{
    // I've kept this console app as thoguh it's being used by the user. For the other stories they would also use the 
    // BadWordService but call different methods. For adding managing the bad word you would use the BadWordRepository.
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
