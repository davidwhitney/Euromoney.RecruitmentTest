using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.DataRepository
{
    /// <summary>
    /// A word repository which loads a file of words separated into different lines
    /// </summary>
    public class BannedWordFileRepository : BannedWordRepository
    {
        private readonly string _filename;

        /// <summary>
        /// Initialize banned word repository with a file.
        /// </summary>
        /// <param name="filename">location of the banned word file, separated by lines</param>
        public BannedWordFileRepository(string filename) : base()
        {
            _filename = filename;
            Read();
        }

        /// <summary>
        /// Read the file into the repository. Throws FileNotFound exception if file is not found
        /// </summary>
        private void Read()
        {
            string[] lines = System.IO.File.ReadAllLines(_filename);
            foreach (string bannedWord in lines)
            {
                Add(bannedWord);
            }
        }

        /// <summary>
        /// Save the repository changes to file
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
