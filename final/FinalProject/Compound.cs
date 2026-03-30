using System.Collections.Generic;
using System.Text;

public class Compound : Substance
{
    private Dictionary<Element, int> _composition;

    public Compound(string name, Dictionary<Element, int> composition)
        : base(name, CalculateMolarMass(composition))
    {
        _composition = composition;
    }

    private static double CalculateMolarMass(Dictionary<Element, int> composition)
    {
        double total = 0;

        foreach (KeyValuePair<Element, int> pair in composition)
        {
            Element element = pair.Key;
            int count = pair.Value;

            total = total + (element.GetMolarMass() * count);
        }

        return total;
    }

    public override string GetFormula()
    {
        StringBuilder formula = new StringBuilder();

        foreach (KeyValuePair<Element, int> pair in _composition)
        {
            formula.Append(pair.Key.GetFormula());

            if (pair.Value > 1)
            {
                formula.Append(pair.Value);
            }
        }

        return formula.ToString();
    }

    public int GetElementCount(Element element)
    {
        if (_composition.ContainsKey(element))
        {
            return _composition[element];
        }
        else
        {
            return 0;
        }
    }

    public List<Element> GetElements()
    {
        List<Element> elements = new List<Element>();

        foreach (KeyValuePair<Element, int> pair in _composition)
        {
            elements.Add(pair.Key);
        }

        return elements;
    }
}