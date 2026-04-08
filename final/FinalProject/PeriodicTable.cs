using System.Collections.Generic;

public class PeriodicTable
{
    private Dictionary<string, Element> _elements;

    public PeriodicTable()
    {
        _elements = new Dictionary<string, Element>();

        AddElement(new Element("Hydrogen", "H", 1, 1.008));
        AddElement(new Element("Oxygen", "O", 8, 16.00));
        AddElement(new Element("Carbon", "C", 6, 12.01));
        AddElement(new Element("Nitrogen", "N", 7, 14.01));
        AddElement(new Element("Sodium", "Na", 11, 22.99));
        AddElement(new Element("Chlorine", "Cl", 17, 35.45));
    }

    private void AddElement(Element element)
    {
        _elements[element.GetFormula()] = element;
    }

    public Element GetElement(string symbol)
    {
        if (_elements.ContainsKey(symbol))
        {
            return _elements[symbol];
        }
        else
        {
            return null;
        }
    }

    public bool ContainsElement(string symbol)
    {
        return _elements.ContainsKey(symbol);
    }

    public List<string> GetAvailableSymbols()
    {
        List<string> symbols = new List<string>();

        foreach (KeyValuePair<string, Element> pair in _elements)
        {
            symbols.Add(pair.Key);
        }

        return symbols;
    }
}