using System;
using System.Text;

namespace ContentConsole
{
	public class Words
	{
		public Words()
		{
		}

		public static string createKey(string word)
		{
			return Words.strippedWord(word.ToLower());
		}

		public static string strippedWord(string word)
		{
			int start = getStart(word);
			int end = getEnd(word);

			return word.Substring(start, end + 1);
		}

		public static string filteredWord(string word)
		{
			if (word.Length < 3)
			{
				StringBuilder hashes = new StringBuilder();

				for (int i = 0; i < word.Length; i++)
				{
					hashes.Append('#');
				}

				return hashes.ToString();

			}
			int start = getStart(word);
			int end = getEnd(word);

			start++;
			end--;

			StringBuilder filtered = new StringBuilder();
			filtered.Append(word.Substring(0, start));

			while (start <= end)
			{
				filtered.Append('#');
				start++;
			}

			int endLength = word.Length - (end + 1);

			filtered.Append(word.Substring(end + 1, endLength));
			return filtered.ToString();

		}

		private static int getStart(string word)
		{
			int start = 0;
			while (start < word.Length - 1 && char.IsPunctuation(word[start]))
			{
				start++;
			}
			return start;
		}

		private static int getEnd(string word)
		{
			int end = word.Length - 1;
			while (end > 0 && char.IsPunctuation(word[end]))
			{
				end--;
			}
			return end;
		}
	}
}
