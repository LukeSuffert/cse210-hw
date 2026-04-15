using System;
using System.Collections.Generic;

public class UserInterface
{
    private ReactionFactory _factory;
    private PeriodicTable _table;

    public UserInterface()
    {
        _table = new PeriodicTable();
        _factory = new ReactionFactory(_table);
    }

    public void Run()
    {
        Console.WriteLine("=== Chemical Reaction Simulator ===");
        Console.WriteLine("Available elements: H, O, C, N, Na, Cl, F");
        Console.WriteLine("Enter a reaction (example: H2 + O2 or CH4 + O2):");

        string input = Console.ReadLine();

        try
        {
            Reaction reaction = _factory.CreateReaction(input);
            reaction.Balance();

            Console.WriteLine();
            Console.WriteLine("Reaction Type: " + reaction.GetReactionType());
            Console.WriteLine("Balanced Equation: " + reaction.GetBalancedEquation());
            Console.WriteLine();

            Dictionary<Compound, double> amountsInGrams = GetReactantAmounts(reaction);

            StoichiometryCalculator calculator = new StoichiometryCalculator(reaction);
            Compound limitingReactant = calculator.FindLimitingReactant(amountsInGrams);
            Compound mainProduct = calculator.GetMainProduct();

            if (limitingReactant == null || mainProduct == null)
            {
                Console.WriteLine("Could not complete stoichiometry calculation.");
                return;
            }

            double theoreticalYield = calculator.CalculateTheoreticalYield(limitingReactant, mainProduct, amountsInGrams);

            Console.WriteLine();
            Console.WriteLine("Limiting Reactant: " + limitingReactant.GetFormula());
            Console.WriteLine("Target Product: " + mainProduct.GetFormula());
            Console.WriteLine("Theoretical Yield: " + theoreticalYield.ToString("F2") + " g");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private Dictionary<Compound, double> GetReactantAmounts(Reaction reaction)
    {
        Dictionary<Compound, double> amounts = new Dictionary<Compound, double>();
        List<Compound> reactants = reaction.GetReactants();

        for (int i = 0; i < reactants.Count; i++)
        {
            Compound reactant = reactants[i];
            double grams = ReadPositiveDouble("Enter grams of " + reactant.GetFormula() + ": ");
            amounts.Add(reactant, grams);
        }

        return amounts;
    }

    private double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            double value;
            bool isValid = double.TryParse(input, out value);

            if (isValid && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a valid non-negative number.");
        }
    }
}