using ContentConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentConsole
{
    class ApiClientService : IApiClientService
    {     
        public string GetContent()
        {
            return "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        }
    }
}
