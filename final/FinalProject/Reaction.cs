using System.Collections.Generic;

public abstract class Reaction
{
    protected List<Compound> _reactants;
    protected List<Compound> _products;
    protected Dictionary<Compound, int> _coefficients; // for balancing later

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

    public abstract void CalculateProducts();
    public abstract string GetReactionType(); 

    public virtual void Balance()
    {
        foreach (var r in _reactants)
            _coefficients[r] = 1;

        foreach (var p in _products)
            _coefficients[p] = 1;
    }

    public Dictionary<Compound, int> GetCoefficients()
    {
        return _coefficients;
    }
}