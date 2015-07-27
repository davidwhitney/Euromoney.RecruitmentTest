using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ContentConsole
{
    class GetContent
    {
        public string NewContent()
        {
            Console.WriteLine("Enter new content: ");
            Console.WriteLine();
            Variables.SetContent(Console.ReadLine());
            return Variables.GetContent();
        }
    }
}
