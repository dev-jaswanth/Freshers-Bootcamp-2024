using TaskManager;

public class PrintScanner : IPrinter, IScanner
{
    private readonly IPrinter printer;
    private readonly IScanner scanner;

    public PrintScanner()
    {
        this.printer = new Printer();
        this.scanner = new Scanner();
    }

    public void Print(string document)
    {
        // First scan, then print
        ScanAndPrint(document);
    }

    public void Scan(string document)
    {
        // First scan, then print
        ScanAndPrint(document);
    }

    private void ScanAndPrint(string document)
    {
        // Scanning the document
        scanner.Scan(document);
        // Printing the document
        printer.Print(document);
    }
}
