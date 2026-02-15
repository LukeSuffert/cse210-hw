using System;

public class Reference
{
    private string _book;

    private int _chapter;

    private int _startVerse;

    private int? _endVerse;


    public Reference(string book, int chpt, int verse)
    {
        _book = book;
        _chapter = chpt;
        _startVerse = verse;
        _endVerse = null;

    }


    public Reference(string book, int chpt, int startV, int endV)
    {
        _book = book;
        _chapter = chpt;
        _startVerse = startV;
        _endVerse = endV;
        
    }   
     public string GetDisplay()
    {
        if (_endVerse == null)
        {
            return $"{_book} {_chapter}: {_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}: {_startVerse}-{_endVerse}";
        }
    }

}




