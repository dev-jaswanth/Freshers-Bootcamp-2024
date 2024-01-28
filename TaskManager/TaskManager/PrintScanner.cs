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
        
        printer.Print(document);
    }

    public void Scan(string document)
    {
       
        scanner.Scan(document);
    }

    
}
