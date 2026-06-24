using System.Xml.Linq;

namespace ConsoleApp1;
public class XmlFileReader : BaseFileReader
    {
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        //string fullText = File.ReadAllText(filePath);
        XDocument doc = XDocument.Load(filePath);

        // int lineCount = fullText.Split('\n').Length;
        string XMLContent = doc.ToString();

        int NodeCount = doc.Descendants().Count();

        Console.WriteLine($" -> Root element: <{doc.Root!.Name}> with {NodeCount} descendant notes.");

        string displayContent = XMLContent.Length > 100
            ? XMLContent.Substring(0, 100) + "..."
            : XMLContent;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}
