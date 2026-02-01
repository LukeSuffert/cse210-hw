using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save as CSV
    public void SaveToFile(string filename)
    {
        if (!filename.EndsWith(".csv"))
        {
            filename += ".csv";
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Header row (Excel-friendly)
            writer.WriteLine("Date,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToCsvString());
            }
        }
    }

    // Load from CSV
    public void LoadFromFile(string filename)
    {
        if (!filename.EndsWith(".csv"))
        {
            filename += ".csv";
        }

        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            bool isHeader = true;

            while ((line = reader.ReadLine()) != null)
            {
                // Skip header
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                List<string> fields = ParseCsvLine(line);

                if (fields.Count >= 3)
                {
                    string date = fields[0];
                    string prompt = fields[1];
                    string response = fields[2];

                    Entry entry = new Entry(date, prompt, response);
                    _entries.Add(entry);
                }
            }
        }
    }

    // CSV handling quotes and commas
    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder field = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    // Escaped quote
                    field.Append('"');
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(field.ToString());
                field.Clear();
            }
            else
            {
                field.Append(c);
            }
        }

        fields.Add(field.ToString());
        return fields;
    }
}
