using System.Collections.Generic;

namespace ContentConsole
{
    public interface IBadWordRepository
    {
        IEnumerable<string> GetAll();
        void Add(string badWord);
        void Remove(string badWord);
    }
}
