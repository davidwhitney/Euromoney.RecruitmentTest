using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Services
{
    /// <summary>
    /// Replaces banned words with another character
    /// </summary>
    public interface IBannedWordReplacementService
    {
        /// <summary>
        /// Replaces banned words with the replacement character. 
        /// If the words are less than three characters long then the entire word is replaced, 
        /// otherwise only the first and last characters will be shown.
        /// </summary>
        /// <param name="content">The content to process</param>
        /// <param name="replacementCharacter">The character to replace the banned word characters with</param>
        /// <returns>A string with the banned words replaced.</returns>
        string ReplaceBannedWords(string content, char replacementCharacter = '#');
    }
}
