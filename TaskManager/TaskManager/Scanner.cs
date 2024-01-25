using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Scanner : IScanner
    {
        public void Scan(string document)
        {
            Console.WriteLine($"Scanning .....{document}");
        }
    }

}
