using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Printer : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing .....{document}");
        }
    }

}
