using System.Collections.Generic;

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

    public virtual void Balance()
    {
        for (int i = 0; i < _reactants.Count; i++)
        {
            Compound reactant = _reactants[i];
            _coefficients[reactant] = 1;
        }

        for (int i = 0; i < _products.Count; i++)
        {
            Compound product = _products[i];
            _coefficients[product] = 1;
        }
    }
}