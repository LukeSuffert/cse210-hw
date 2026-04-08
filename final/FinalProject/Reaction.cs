using System.Collections.Generic;
using System.Text;

public abstract class Reaction
{
    protected List<Compound> _reactants;
    protected List<Compound> _products;
    protected Dictionary<Compound, int> _coefficients;

    public Reaction(List<Compound> reactants)
    {
        _reactants = reactants;
        _products = new List<Compound>();
        _coefficients = new Dictionary<Compound, int>();
    }

    public List<Compound> GetReactants()
    {
        return _reactants;
    }

    public List<Compound> GetProducts()
    {
        return _products;
    }

    public Dictionary<Compound, int> GetCoefficients()
    {
        return _coefficients;
    }

    public abstract void CalculateProducts();
    public abstract string GetReactionType();
    public abstract void Balance();

    public string GetBalancedEquation()
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < _reactants.Count; i++)
        {
            Compound reactant = _reactants[i];
            int coefficient = _coefficients[reactant];

            if (coefficient > 1)
            {
                builder.Append(coefficient);
            }

            builder.Append(reactant.GetFormula());

            if (i < _reactants.Count - 1)
            {
                builder.Append(" + ");
            }
        }

        builder.Append(" -> ");

        for (int i = 0; i < _products.Count; i++)
        {
            Compound product = _products[i];
            int coefficient = _coefficients[product];

            if (coefficient > 1)
            {
                builder.Append(coefficient);
            }

            builder.Append(product.GetFormula());

            if (i < _products.Count - 1)
            {
                builder.Append(" + ");
            }
        }

        return builder.ToString();
    }
}