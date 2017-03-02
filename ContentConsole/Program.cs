using System;
using System.Collections.Generic;

namespace ContentConsole
{
	public static class Program
	{


		public static void Main(string[] args)
		{
			Database db = new Database();
			ContentManager myContent = new ContentManager(db);

			bool running = true;
			ConsoleKeyInfo lastKey;
			char keyChar;

			while (running)
			{
				Console.WriteLine("What would you like to do?");
				Console.WriteLine("1: (User)----------- Update / scan content");
				Console.WriteLine("2: (Administrator)-- Update negative word list");
				Console.WriteLine("3: (Reader)--------- Read our content");
				Console.WriteLine("4: (Content Curator) See unfiltered content");
				Console.WriteLine("5: Quit");
				Console.WriteLine();
				Console.Write("Enter choice: ");

				lastKey = Console.ReadKey();
				keyChar = lastKey.KeyChar;
				Console.WriteLine();


				if (keyChar == '1')
				{
					seeNegativeWords(myContent);
					pause();
				}
				else if (keyChar == '2')
				{
					updateNegativeWords(myContent);
					pause();
				}
				else if (keyChar == '3')
				{
					readContent(myContent);
					pause();
				}
				else if (keyChar == '4')
				{
					readContentUnfiltered(myContent);
					pause();
				}
				else if (keyChar == '5')
				{
					running = false;
				}
			}

			Console.WriteLine("Press ANY key to exit.");
			Console.ReadKey();
		}

		//Story 1
		public static void seeNegativeWords(ContentManager myContent)
		{
			Console.WriteLine("Enter the new content to scan: ");
			Console.WriteLine();

			myContent.updateContent(Console.ReadLine());

		}

		//Story 2
		public static void updateNegativeWords(ContentManager myContent)
		{
			ConsoleKeyInfo lastKey;
			char keyChar;
			while (true)
			{
				Console.WriteLine("Do you want to add or remove a negative word?");
				Console.WriteLine("1: Add");
				Console.WriteLine("2: Remove");
				Console.WriteLine("3: Quit");
				Console.WriteLine();
				Console.Write("Enter choice: ");

				lastKey = Console.ReadKey();
				keyChar = lastKey.KeyChar;
				Console.WriteLine();


				if (keyChar == '1')
				{
					addWord(myContent);
					pause();
				}
				else if (keyChar == '2')
				{
					removeWord(myContent);
					pause();
				}
				else if (keyChar == '3')
				{
					return;
				}
			}

		}

		//Story 3
		public static void readContent(ContentManager myContent)
		{
			Console.WriteLine("Here is today's top story: ");
			Console.WriteLine();
			Console.WriteLine(myContent.getFilteredContent());
		}

		//Story 4
		public static void readContentUnfiltered(ContentManager myContent)
		{
			int badWords = myContent.getBadWordCount();
			Console.WriteLine("Not filtering " + badWords + " bad words.");

			Console.WriteLine("Content: ");
			Console.WriteLine(myContent.getContent());
		}

		public static void addWord(ContentManager myContent)
		{
			Console.WriteLine("Enter word to be added to negative word list: ");
			string line = Console.ReadLine().ToString();
			while (line.Contains(" "))
			{
				Console.WriteLine("Please enter one word at a time (no spaces): ");
				line = Console.ReadLine().ToString();
			}

			if (!myContent.AddBadWord(line))
			{
				Console.WriteLine(line + " is already considered a negative word.");
			}
			else
			{
				Console.WriteLine(line + " added to negative word list.");
			}
		}

		public static void removeWord(ContentManager myContent)
		{
			Console.WriteLine("Enter word to be removed from negative word list: ");
			string line = Console.ReadLine().ToString();
			while (line.Contains(" "))
			{
				Console.WriteLine("Please enter one word at a time (no spaces): ");
				line = Console.ReadLine().ToString();
			}

			if (!myContent.RemoveBadWord(line))
			{
				Console.WriteLine(line + " is not considered a negative word.");
			}
			else
			{
				Console.WriteLine(line + " removed from negative word list.");
			}
		}

		public static void pause()
		{
			Console.WriteLine();
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			Console.WriteLine();
		}

	}

}
