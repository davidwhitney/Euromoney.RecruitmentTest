using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
		 
        public static void Main(string[] args)
        {
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");
           
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
			
			//if "replace" is false, the worlds are not replaced
			//if "caseSensitive" is false, the detection of the bad worlds will not be case sensitive
			FilterResult result = Filter.FilterBannedWorlds (bannedWorlds, content, true, false);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
			Console.WriteLine("Total Number of negative words: " + result.BannedWorldsCount);
			Console.WriteLine ("Output text:");
			Console.WriteLine (result.TextResult);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
