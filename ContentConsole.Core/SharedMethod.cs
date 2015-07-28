namespace ContentConsole.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the core of the program, called by
    /// both the console application and unit test
    /// project.
    /// </summary>
    public class SharedMethod
    {
        private List<string> bannedWords = new List<string> { "swine", "bad", "nasty", "horrible" };

        #region Story 1

        /// <summary>
        /// Counts the banned words in a given sentence.
        /// </summary>
        /// <param name="sentence">The sentence to be analysed.</param>
        /// <returns>The number of banned words.</returns>
        public int CountBannedWords(string sentence)
        {
            int badWordCount = 0;

            foreach (string word in sentence.Split(' '))
            {
                string trimmedWord = TrimPunctuation(word).ToLower();

                if (bannedWords.Contains(trimmedWord))
                {
                    badWordCount += 1;
                }
            }

            return badWordCount;
        }

        #endregion Story 1

        #region Story 2

        public void ResetBannedList()
        {
            bannedWords.Clear();
            List<string> resetWords = new List<string>() { "swine", "bad", "nasty", "horrible" };
            bannedWords = resetWords;
        }

        /// <summary>
        /// Returns the list of banned words
        /// </summary>
        /// <returns>A List<string> that contains the banned words.</returns>
        public List<string> PrintBannedList()
        {
            if (bannedWords != null || bannedWords.Count == 0)
            {
                return bannedWords;
            }
            else
            {
                return new List<string> { "List has no words" };
            }
        }

        /// <summary>
        /// Clears the list of banned words.
        /// </summary>
        /// <returns>A success message to let the user know that the list is now clear.</returns>
        public string ClearBannedList()
        {
            bannedWords.Clear();

            return "List of banned words successfully cleared.";
        }

        /// <summary>
        /// Adds words to the list of banned words.
        /// </summary>
        /// <param name="wordsToAdd">The list of words to add</param>
        /// <returns>The new list of banned words.</returns>
        public List<string> AddWordsToBannedList(List<string> wordsToAdd)
        {
            if (wordsToAdd != null && wordsToAdd.Count != 0)
            {
                foreach (string wordToAdd in wordsToAdd)
                {
                    if (wordToAdd != null && wordToAdd != string.Empty)
                    {
                        bannedWords.Add(wordToAdd.ToLower());
                    }
                    else
                    {
                        throw new ArgumentNullException("wordsToAdd",
                            "User tried to add an invalid string to the list of banned words");
                    }
                }

                return bannedWords;
            }
            else
            {
                throw new ArgumentOutOfRangeException("wordsToAdd",
                    "User tried to add an invalid string to the list of banned words");
            }
        }

        /// <summary>
        /// Removes words from the list of banned words.
        /// </summary>
        /// <param name="wordsToRemove">The list of words to remove</param>
        /// <returns>The new list of banned words.</returns>
        public List<string> RemoveWordsFromBannedList(List<string> wordsToRemove)
        {
            if (wordsToRemove != null && wordsToRemove.Count != 0)
            {
                foreach (string wordToRemove in wordsToRemove)
                {
                    if (wordToRemove != null && wordToRemove != string.Empty)
                    {
                        if (bannedWords.Contains(wordToRemove.ToLower()))
                        {
                            bannedWords.Remove(wordToRemove.ToLower());
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("wordToRemove",
                                "User tried to remove a word that is not in the list of banned words");
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("wordToRemove",
                            "User tried to remove a null value from the list of banned words");
                    }
                }

                if (bannedWords.Count == 0)
                {
                    return new List<string> { "List of banned words is empty." };
                }
                else
                {
                    return bannedWords;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("wordsToRemove",
                    "User tried to remove an invalid string from the list of banned words");
            }
        }

        #endregion Story 2

        #region Story 3

        public string MaskBannedWords(string sentence)
        {
            string newSentence = sentence.ToLower();

            foreach (string word in sentence.Split(' '))
            {
                string trimmedWord = TrimPunctuation(word).ToLower();

                if (bannedWords.Contains(trimmedWord))
                {
                    int numberOfHashes = trimmedWord.Length - 2;

                    string firstChar = trimmedWord.Substring(0, 1);
                    string lastChar = trimmedWord.Substring(trimmedWord.Length - 1, 1);

                    string requiredMask = new string('#', numberOfHashes);
                    string maskedWord = string.Concat(firstChar, requiredMask, lastChar);

                    newSentence = newSentence.Replace(trimmedWord, maskedWord);
                }
            }

            return newSentence;
        }

        #endregion Story 3

        // Not sure if this was needed
        // as the requirements for Story
        // 1 & 4 seem to be identical.
        // (From my understanding anyways.)
        #region Story 4
        #endregion Story 4

        #region Shared Methods

        /// <summary>
        /// This method is to trim any punctuation
        /// from the end of a word; so that banned
        /// words that are at the end of sentences
        /// are counted.
        /// </summary>
        /// <param name="word">current word selected in the sentence.</param>
        /// <returns>the current word but without any trailing punctuation</returns>
        private static string TrimPunctuation(string word)
        {
            // Count trailing punctuation.
            int removeFromEnd = 0;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                if (char.IsPunctuation(word[i]))
                {
                    removeFromEnd++;
                }
                else
                {
                    break;
                }
            }

            // No characters were punctuation.
            if (removeFromEnd == 0)
            {
                return word;
            }

            // Remove the trailing punctuation
            return word.Substring(0, word.Length - removeFromEnd);
        }

        #endregion Shared Methods
    }
}
