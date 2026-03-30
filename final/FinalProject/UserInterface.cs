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
        Console.WriteLine("Available elements: H, O, C, N, Na, Cl");
        Console.WriteLine("Enter a reaction (example: H2 + O2): ");

        string input = Console.ReadLine();

        Reaction reaction = _factory.CreateReaction(input);

        reaction.Balance();

        DisplayBalancedEquation(reaction);
    }

    private void DisplayBalancedEquation(Reaction reaction)
    {
        Console.WriteLine("\nReaction Type: " + reaction.GetReactionType());

        Console.Write("Reactants: ");
        foreach (Compound r in reaction.GetReactants())
        {
            Console.Write(r.GetFormula() + " ");
        }

        Console.Write("\nProducts: ");
        foreach (Compound p in reaction.GetProducts())
        {
            Console.Write(p.GetFormula() + " ");
        }

        Console.WriteLine();
    }
}