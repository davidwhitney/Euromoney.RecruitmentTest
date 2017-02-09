using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Services
{
    /// <summary>
    /// A service which counts the number of instances of banned words
    /// </summary>
    public interface IBannedWordCounterService
    {
        /// <summary>
        /// Counts the banned words in the content
        /// </summary>
        /// <param name="content">The content to process</param>
        /// <returns>Number of banned words found</returns>
        int CountBannedWords(string content);
    }
}

