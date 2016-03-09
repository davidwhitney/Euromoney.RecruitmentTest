using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public interface IDataStore<T>
    {
        /// <summary>
        /// Returns all the items in the store.
        /// </summary>
        /// <returns>All the items in the store.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds an item to the store.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Add(T item);

        /// <summary>
        /// Deletes the item from the store.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        void Delete(T item);

        /// <summary>
        /// Deletes all the items in the store.
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Returns the number of items in the store.
        /// </summary>
        /// <returns>The number of items in the store.</returns>
        int Count();
    }
}
