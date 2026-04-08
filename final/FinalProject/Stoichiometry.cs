using System;
using System.Collections.Generic;

public class StoichiometryCalculator
{
    private Reaction _reaction;

    public StoichiometryCalculator(Reaction reaction)
    {
        _reaction = reaction;
    }

    public Compound FindLimitingReactant(Dictionary<Compound, double> amountsInGrams)
    {
        List<Compound> reactants = _reaction.GetReactants();
        Dictionary<Compound, int> coefficients = _reaction.GetCoefficients();

        Compound limitingReactant = null;
        double smallestRatio = double.MaxValue;

        for (int i = 0; i < reactants.Count; i++)
        {
            Compound reactant = reactants[i];

            if (!amountsInGrams.ContainsKey(reactant))
            {
                continue;
            }

            double grams = amountsInGrams[reactant];
            double molesAvailable = grams / reactant.GetMolarMass();
            int coefficient = coefficients[reactant];
            double ratio = molesAvailable / coefficient;

            if (ratio < smallestRatio)
            {
                smallestRatio = ratio;
                limitingReactant = reactant;
            }
        }

        return limitingReactant;
    }

    public double CalculateTheoreticalYield(Compound limitingReactant, Compound targetProduct, Dictionary<Compound, double> amountsInGrams)
    {
        Dictionary<Compound, int> coefficients = _reaction.GetCoefficients();

        if (!amountsInGrams.ContainsKey(limitingReactant))
        {
            throw new Exception("Missing amount for limiting reactant.");
        }

        double limitingGrams = amountsInGrams[limitingReactant];
        double limitingMoles = limitingGrams / limitingReactant.GetMolarMass();

        int limitingCoefficient = coefficients[limitingReactant];
        int productCoefficient = coefficients[targetProduct];

        double productMoles = limitingMoles * productCoefficient / limitingCoefficient;
        double productGrams = productMoles * targetProduct.GetMolarMass();

        return productGrams;
    }

    public Dictionary<Compound, double> ConvertGramsToMoles(Dictionary<Compound, double> amountsInGrams)
    {
        Dictionary<Compound, double> amountsInMoles = new Dictionary<Compound, double>();
        List<Compound> reactants = _reaction.GetReactants();

        for (int i = 0; i < reactants.Count; i++)
        {
            Compound reactant = reactants[i];

            if (amountsInGrams.ContainsKey(reactant))
            {
                double grams = amountsInGrams[reactant];
                double moles = grams / reactant.GetMolarMass();
                amountsInMoles.Add(reactant, moles);
            }
        }

        return amountsInMoles;
    }

    public Compound GetMainProduct()
    {
        List<Compound> products = _reaction.GetProducts();

        if (products.Count == 0)
        {
            return null;
        }

        return products[0];
    }
}