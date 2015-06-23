using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<string> badWords = new List<string>() {"swine", "bad", "nasty", "horrible"};
            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var textAnalyser = new TextAnalyser(badWords);
            var contentManager = new ContentManager(textAnalyser, content);

            //Story 1
            Console.WriteLine("User can scan text");
            Console.WriteLine(contentManager.ScanText());

            Console.WriteLine();

            //Story 2
            Console.WriteLine("Administrator doesn't like 'people' and adds them to the bad words list");
            contentManager.TextAnalyser.AddBadWord("people");
            Console.WriteLine(contentManager.ScanText());

            Console.WriteLine();

            //Story 3
            Console.WriteLine("When reading, readers should see the filtered bad words instead of the actual ones");
            Console.WriteLine(contentManager.ReadText());

            Console.WriteLine();
            Console.WriteLine("Readers convinced the administrator that 'people' are not that bad so he removed them from the list");
            contentManager.TextAnalyser.RemoveBadWord("people");

            Console.WriteLine();

            Console.WriteLine("Now readers should see the word 'people' not filtered");
            Console.WriteLine(contentManager.ReadText());

            Console.WriteLine();

            //Story 4
            Console.WriteLine("Content Curators wish to see the original text");
            Console.WriteLine(contentManager.ReadText(filter:false));

            Console.WriteLine();

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }


    }

}
