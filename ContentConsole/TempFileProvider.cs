using System;
using System.IO;

namespace ContentConsole
{
    public class TempFileProvider : ITempFileProvider
    {
        const string FILE_NAME = "8FC57C70-59B6-4F78-B2E9-954E73FA258F";
        public TempFileProvider()
        {
            
        }
        public string ReadContent()
        {
            throw new NotImplementedException();
        }

        public void SetContent(string content)
        {
            throw new NotImplementedException();
        }
    }
}
