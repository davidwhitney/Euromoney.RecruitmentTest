using ContentConsole.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public class MemoryDataStore<T> : IDataStore<T>
    {
        private IList<T> _items;

        public MemoryDataStore()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public void Delete(T item)
        {
            _items.Remove(item);
        }

        public void DeleteAll()
        {
            _items.Clear();
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToArray();
        }

        public int Count()
        {
            return _items.Count;
        }
    }
}
