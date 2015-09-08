using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public interface ITempFileProvider
    {
        void SetContent(string content);
        string ReadContent();
    }
}
