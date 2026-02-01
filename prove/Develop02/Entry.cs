using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    // CSV
    public string ToCsvString()
    {
        return $"{EscapeCsv(_date)},{EscapeCsv(_prompt)},{EscapeCsv(_response)}";
    }

    // CSV escape logic
    private string EscapeCsv(string value)
    {
        if (value.Contains("\""))
        {
            value = value.Replace("\"", "\"\"");
        }

        if (value.Contains(",") || value.Contains("\n") || value.Contains("\""))
        {
            value = $"\"{value}\"";
        }

        return value;
    }
}
