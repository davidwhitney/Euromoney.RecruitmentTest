using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class BannedWords : IBannedWords
    {
        private static List<string> _bannedWords;
        public IEnumerable<string> List
        {
            get
            {
                return _bannedWords;
            }
        }
    }
}
