using System;
using System.Dynamic;

public enum DisplayMode
    {
        Normal,
        Hidden,
        FirstLetter
    }

public class Word
{
    private string _text;
    private bool _hidden;


    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetDisplay(DisplayMode mode)
    {
  
        if (mode == DisplayMode.FirstLetter)
        {
            return _text[0] + new string('_', _text.Length - 1);
        }

        if (_hidden)
        {
            return new string('_', _text.Length);
        }

        else
        {
            return _text;
        }

    }


}


