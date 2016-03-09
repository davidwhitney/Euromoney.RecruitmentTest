using ContentConsole.Core;
using System;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var analyser = new ContentAnalyser(new MemoryDataStore<string>(), new WordCounter(), new WordFilter());
            analyser.Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            analyser.AddNegativeWord("swine");
            analyser.AddNegativeWord("bad");
            analyser.AddNegativeWord("nasty");
            analyser.AddNegativeWord("horrible");

            var canExit = false;

            // Assume the user has access to all the options, no matter the role
            do
            {
                PrintMenu();
                var option = GetOption();
                switch (option)
                {
                    case Option.ShowContent:
                        Console.WriteLine("Content: " + analyser.Content);
                        break;

                    case Option.ChangeContent:
                        Console.Write("Enter the new content: ");
                        var newContent = Console.ReadLine();
                        analyser.Content = newContent;
                        break;

                    case Option.CountWords:
                        Console.WriteLine("Content:");
                        Console.WriteLine(analyser.Content);
                        Console.WriteLine("Number of negative words: " + analyser.CountNegativeWords());
                        break;

                    case Option.ShowWords:
                        Console.WriteLine("Current negative words: " + string.Join(", ", analyser.GetNegativeWords()));
                        break;

                    case Option.ChangeWords:
                        Console.Write("Enter the new list of negative words (separated by spaces): ");
                        var newWords = Console.ReadLine();
                        analyser.DeleteAllNegativeWords();
                        var nonBlankNewWords = newWords.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s));
                        foreach (var word in nonBlankNewWords)
                        {
                            analyser.AddNegativeWord(word.Trim());
                        }
                        Console.WriteLine("The new list of negative words: " + string.Join(", ", analyser.GetNegativeWords()));
                        break;

                    case Option.FilterWords:
                        Console.WriteLine("Original text: " + analyser.Content);
                        Console.WriteLine("Filtered text: " + analyser.FilterNegativeWords());
                        break;

                    case Option.EnableFilter:
                        analyser.EnableFilter();
                        Console.WriteLine("The negative words filter is enabled");
                        break;

                    case Option.DisableFilter:
                        analyser.DisableFilter();
                        Console.WriteLine("The negative words filter is disabled");
                        break;

                    case Option.Exit:
                        canExit = true;
                        break;

                    default:
                        break;
                }
            } while (!canExit);
        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Display the content");
            Console.WriteLine("2. Change the content");
            Console.WriteLine("3. Count negative words");
            Console.WriteLine("4. Display the set of negative words");
            Console.WriteLine("5. Change the set of negative words");
            Console.WriteLine("6. Filter the content");
            Console.WriteLine("7. Enable filter");
            Console.WriteLine("8. Disable filter");
            Console.WriteLine("9. Exit");
            Console.WriteLine();
        }

        private static Option GetOption()
        {
            var input = Console.ReadKey(true);
            switch (input.KeyChar)
            {
                case '1':
                    return Option.ShowContent;
                case '2':
                    return Option.ChangeContent;
                case '3':
                    return Option.CountWords;
                case '4':
                    return Option.ShowWords;
                case '5':
                    return Option.ChangeWords;
                case '6':
                    return Option.FilterWords;
                case '7':
                    return Option.EnableFilter;
                case '8':
                    return Option.DisableFilter;
                case '9':
                    return Option.Exit;
                default:
                    return Option.None;
            }
        }

        private enum Option
        {
            None,
            ShowContent,
            ChangeContent,
            CountWords,
            ShowWords,
            ChangeWords,
            FilterWords,
            EnableFilter,
            DisableFilter,
            Exit
        }
    }
}
