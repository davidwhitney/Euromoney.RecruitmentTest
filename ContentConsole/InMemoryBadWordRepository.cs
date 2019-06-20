using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public class InMemoryBadWordRepository : IBadWordRepository
    {
        ICollection<string> badWords;

        public InMemoryBadWordRepository()
        {
            badWords = new List<string>()
            {
                "swine",
                "bad",
                "nasty",
                "horrible"
            };
        }

        public void Add(string badWord)
        {

            if (badWord == null)
            {
                throw new ArgumentNullException(nameof(badWord), $"Argument {nameof(badWord)} cannot be null");
            }
            else if (
              badWord == string.Empty)
            {
                throw new ArgumentException(nameof(badWord), $"Argument {nameof(badWord)} cannot be an empty string");
            }

            if (!badWords.Contains(badWord))
            {
                badWords.Add(badWord.ToLowerInvariant());
            }

        }

        public IEnumerable<string> GetAll()
        {
            return badWords;
        }

        public void Remove(string badWord)
        {
            if (badWord == null)
            {
                throw new ArgumentNullException(nameof(badWord), $"Argument {nameof(badWord)} cannot be null");
            }
            else if (
              badWord == string.Empty)
            {
                throw new ArgumentException(nameof(badWord), $"Argument {nameof(badWord)} cannot be an empty string");
            }

            badWords.Remove(badWord);
        }
    }
}
