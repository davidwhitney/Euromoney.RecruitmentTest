using System;
using System.Collections.Generic;

namespace ContentConsole
{
	public class Database
	{
		public string content;
		public Dictionary<string, int> contentWordCounts;
		public HashSet<string> badWordSet;
		public int badWordCount;
		public string filteredContent;
		public bool badWordsChanged;
		public Database()
		{
			badWordSet = new HashSet<string>();
			contentWordCounts = new Dictionary<string, int>();

			badWordSet.Add("swine");
			badWordSet.Add("bad");
			badWordSet.Add("nasty");
			badWordSet.Add("horrible");

			content =
				"The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

			badWordsChanged = false;
		}
	}
}
