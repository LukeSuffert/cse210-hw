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
        foreach (var pair in composition)
        {
            total += pair.Key.GetMolarMass() * pair.Value;
        }
        return total;
    }

    public override string GetFormula()
    {
        StringBuilder formula = new StringBuilder();
        foreach (var pair in _composition)
        {
            formula.Append(pair.Key.GetFormula());
            if (pair.Value > 1)
                formula.Append(pair.Value);
        }
        return formula.ToString();
    }

    public int GetElementCount(Element element)
    {
        return _composition.ContainsKey(element) ? _composition[element] : 0;
    }
}