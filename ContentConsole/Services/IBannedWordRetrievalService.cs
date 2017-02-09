using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Services
{

    /// <summary>
    /// Retrieves an enumerable of banned words
    /// </summary>
    public interface IBannedWordRetrievalService
    {
        /// <summary>
        /// Get banned words
        /// </summary>
        /// <returns>An IEnumerable of banned words</returns>
        IEnumerable<string> GetBannedWords();
    }
}
