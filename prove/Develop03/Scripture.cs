using System;

public class Scripture
{
    private Reference _ref;

    private List<Word> _words;

    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _ref = reference;
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }

        _random = new Random();
    }

    public void Display()
    {
        Console.WriteLine(GetDisplayText("normal"));
    }

    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public String GetDisplayText(string mode)
    {
        DisplayMode displayMode = (DisplayMode)Enum.Parse(typeof(DisplayMode), mode);
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplay(displayMode)));
        return $"{_ref.GetDisplay()} {wordsText}";
    }

}