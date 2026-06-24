using System.Text.Json;

namespace ConsoleApp1;

public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string JsonText = File.ReadAllText(filePath);

        using JsonDocument doc = JsonDocument.Parse(JsonText);

        int propertyCount = 0;

        if (doc.RootElement.ValueKind == JsonValueKind.Object)
        {
            propertyCount = doc.RootElement
                .EnumerateObject()
                .Count();
        }
        else if (doc.RootElement.ValueKind == JsonValueKind.Array)
        {
            propertyCount = doc.RootElement
                .EnumerateArray()
                .Count();
        }

            Console.WriteLine($" -> Parsed {propertyCount} root properties.");

        string displayContent = JsonText.Length > 100
            ? JsonText.Substring(0, 100) + "..."
            : JsonText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}

