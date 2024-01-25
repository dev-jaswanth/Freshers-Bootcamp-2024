using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class TaskManager
    {
        public static void ExecutePrintTask(IPrinter printer, string documentPath)
        {
            printer.Print(documentPath);
        }

        public static void ExecuteScanTask(IScanner scanner, string documentPath)
        {
            scanner.Scan(documentPath);
        }
    }

}
