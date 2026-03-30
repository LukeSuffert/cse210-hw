using System;
using System.Collections.Generic;

public class ReactionFactory
{
    private PeriodicTable _table;

    public ReactionFactory(PeriodicTable table)
    {
        _table = table;
    }

    public Reaction CreateReaction(string input)
    {
        string[] parts = input.Split('+');

        List<Compound> reactants = new List<Compound>();

        foreach (string part in parts)
        {
            Compound compound = ParseCompound(part.Trim());
            reactants.Add(compound);
        }

        string type = DetectReactionType(reactants);

        if (type == "Synthesis")
        {
            return new SynthesisReaction(reactants);
        }
        else
        {
            return new SynthesisReaction(reactants);
        }
    }

    private string DetectReactionType(List<Compound> reactants)
    {
        if (reactants.Count == 1)
        {
            return "Decomposition";
        }

        foreach (Compound c in reactants)
        {
            if (c.GetFormula().Contains("O2"))
            {
                return "Combustion";
            }
        }

        return "Synthesis";
    }

            private Compound ParseCompound(string formula)
    {
        Dictionary<Element, int> composition = new Dictionary<Element, int>();

        for (int i = 0; i < formula.Length; i++)
        {
            string symbol = formula[i].ToString();

            if (i + 1 < formula.Length && char.IsLower(formula[i + 1]))
            {
                symbol = symbol + formula[i + 1].ToString();
                i++;
            }

            int count = 1;

            if (i + 1 < formula.Length && char.IsDigit(formula[i + 1]))
            {
                count = int.Parse(formula[i + 1].ToString());
                i++;
            }

            Element element = _table.GetElement(symbol);

            if (element == null)
            {
                throw new Exception("Unknown element: " + symbol);
            }

            if (composition.ContainsKey(element))
            {
                composition[element] = composition[element] + count;
            }
            else
            {
                composition.Add(element, count);
            }
        }

        Compound compound = new Compound(formula, composition);
        return compound;
    }
}
    