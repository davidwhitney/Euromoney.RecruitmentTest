using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole.Interfaces
{
    public interface IUserInputHandler
    {
        public string InputLine();

        public string YesNoHandling();

        public string ReadKey();
    }
}
