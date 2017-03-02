using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole
{
	public class ContentManager
	{
		private Database myDB;

		public ContentManager(Database db)
		{
			myDB = db;
			countBadWords();
			createFilteredContent();
		}

		public int updateContent(String newContent)
		{

			myDB.content = newContent;

			int badWords = countBadWords();
			createFilteredContent();

			Console.WriteLine("Scanned the text:");
			printContent();
			Console.WriteLine();
			printBadWords();

			return badWords;
		}

		private int countBadWords()
		{

			int badWordCount = 0;
			HashSet<string> badWordSet = myDB.badWordSet;
			string[] contentArr = myDB.content.Split(' ');

			for (int i = 0; i < contentArr.Length; i++)
			{
				string curWord = Words.createKey(contentArr[i]);
				countWord(curWord);

				if (badWordSet.Contains(curWord))
				{
					badWordCount++;
				}

			}
			myDB.badWordCount = badWordCount;
			return badWordCount;
		}

		private void countWord(string word)
		{
			Dictionary<string, int> contentWordCounts = myDB.contentWordCounts;
			if (!contentWordCounts.ContainsKey(word))
			{
				contentWordCounts[word] = 1;
			}
			else
			{
				contentWordCounts[word] += 1;
			}
			myDB.contentWordCounts = contentWordCounts;
		}

		public bool isBadWord(string word)
		{
			return myDB.badWordSet.Contains(Words.createKey(word));
		}

		public bool AddBadWord(string word)
		{
			HashSet<string> badWordSet = myDB.badWordSet;
			word = Words.createKey(word);
			if (badWordSet.Contains(word))
			{
				return false;
			}

			badWordSet.Add(word);
			Dictionary<string, int> contentWordCounts = myDB.contentWordCounts;

			if (contentWordCounts.ContainsKey(word))
			{
				int badWordCount = myDB.badWordCount;
				badWordCount += contentWordCounts[word];
				myDB.badWordCount = badWordCount;
			}
			myDB.badWordsChanged = true;
			return true;
		}

		public bool RemoveBadWord(string word)
		{
			HashSet<string> badWordSet = myDB.badWordSet;
			word = Words.createKey(word);
			if (!badWordSet.Contains(word))
			{
				return false;
			}

			badWordSet.Remove(word);
			Dictionary<string, int> contentWordCounts = myDB.contentWordCounts;


			if (contentWordCounts.ContainsKey(word))
			{
				int badWordCount = myDB.badWordCount;
				badWordCount -= contentWordCounts[word];
				myDB.badWordCount = badWordCount;

			}
			myDB.badWordsChanged = true;
			return true;
		}


		private void createFilteredContent()
		{
			string[] words = myDB.content.Split(' ');

			for (int i = 0; i < words.Length; i++)
			{

				if (isBadWord(words[i]))
				{
					words[i] = Words.filteredWord(words[i]);
				}
			}

			myDB.filteredContent = String.Join(" ", words);
		}

		private void printContent()
		{
			Console.WriteLine(getContent());
		}

		private void printBadWords()
		{
			Console.WriteLine("Total Number of negative words: " + myDB.badWordCount);
		}

		public string getFilteredContent()
		{
			if (myDB.badWordsChanged)
			{
				createFilteredContent();
				myDB.badWordsChanged = false;
			}
			return myDB.filteredContent;
		}

		public int getBadWordCount() { return myDB.badWordCount; }
		public string getContent() { return myDB.content; }
	}
}
