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

        for (int i = 0; i < parts.Length; i++)
        {
            string trimmedPart = parts[i].Trim();

            if (trimmedPart != "")
            {
                Compound compound = ParseCompound(trimmedPart);
                reactants.Add(compound);
            }
        }

        string reactionType = DetectReactionType(reactants);

        if (reactionType == "Synthesis")
        {
            return new SynthesisReaction(reactants);
        }
        else if (reactionType == "Decomposition")
        {
            return new DecompositionReaction(reactants);
        }
        else if (reactionType == "Combustion")
        {
            return new CombustionReaction(reactants);
        }
        else
        {
            throw new Exception("Unsupported reaction type.");
        }
    }

    private string DetectReactionType(List<Compound> reactants)
    {
        if (reactants.Count == 1)
        {
            return "Decomposition";
        }

        if (reactants.Count == 2)
        {
            bool hasOxygenGas = false;
            bool hasHydrocarbon = false;

            for (int i = 0; i < reactants.Count; i++)
            {
                Compound reactant = reactants[i];
                string formula = reactant.GetFormula();

                if (formula == "O2")
                {
                    hasOxygenGas = true;
                }

                if (IsHydrocarbon(reactant))
                {
                    hasHydrocarbon = true;
                }
            }

            if (hasOxygenGas && hasHydrocarbon)
            {
                return "Combustion";
            }

            return "Synthesis";
        }

        throw new Exception("This program currently supports only one or two reactants.");
    }

    private bool IsHydrocarbon(Compound compound)
    {
        List<Element> elements = compound.GetElements();
        bool hasCarbon = false;
        bool hasHydrogen = false;

        for (int i = 0; i < elements.Count; i++)
        {
            string symbol = elements[i].GetFormula();

            if (symbol == "C")
            {
                hasCarbon = true;
            }
            else if (symbol == "H")
            {
                hasHydrogen = true;
            }
            else
            {
                return false;
            }
        }

        return hasCarbon && hasHydrogen;
    }

    private Compound ParseCompound(string formula)
    {
        Dictionary<Element, int> composition = new Dictionary<Element, int>();

        for (int i = 0; i < formula.Length; i++)
        {
            if (!char.IsLetter(formula[i]))
            {
                continue;
            }

            string symbol = formula[i].ToString();

            if (i + 1 < formula.Length && char.IsLower(formula[i + 1]))
            {
                symbol = symbol + formula[i + 1].ToString();
                i++;
            }

            int count = 1;
            string numberText = "";

            while (i + 1 < formula.Length && char.IsDigit(formula[i + 1]))
            {
                numberText = numberText + formula[i + 1].ToString();
                i++;
            }

            if (numberText != "")
            {
                count = int.Parse(numberText);
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