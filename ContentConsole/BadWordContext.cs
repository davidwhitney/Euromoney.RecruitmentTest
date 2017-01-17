using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;

namespace ContentConsole
{
    public class BadWordContext : DbContext
    {
        public BadWordContext()
        {
            BadWords = new List<BadWord>();
                        
            //default data for now (expected to come from DB etc.)
            BadWords.Add(new BadWord("swine"));
            BadWords.Add(new BadWord("bad"));
            BadWords.Add(new BadWord("nasty"));
            BadWords.Add(new BadWord("horrible"));             
        }

        public virtual List<BadWord> BadWords { get; set; }
    }
}
