using System.Collections.Generic;

namespace ContentConsole
{
    public class InMemoryBadWordRepository : IBadWordRepository
    {
        IEnumerable<string> badWords;

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
        public IEnumerable<string> GetAll()
        {
            return badWords;
        }
    }
}
