namespace ConsoleApp1;

public class CsvFileReader : BaseFileReader
{
    public override string SupportedFormat => "CSV";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening CSV stream...");

        string[] lines = File.ReadAllLines (filePath);
        int RowCount = lines.Length;

        int ColumnCount = RowCount > 0
            ? lines[0].Split(',').Length 
            : 0;        

        Console.WriteLine($" -> Detected {RowCount} rows and {ColumnCount} columns.");

        string fullText = File.ReadAllText(filePath);

        string displayContent = fullText.Length > 100
            ? fullText.Substring(0, 100) + "..."
            : fullText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}
