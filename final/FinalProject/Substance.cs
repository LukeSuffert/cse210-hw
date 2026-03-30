public abstract class Substance
{
    private string _name;
    private double _molarMass;

    protected Substance(string name, double molarMass)
    {
        _name = name;
        _molarMass = molarMass;
    }

    public double GetMolarMass()
    {
        return _molarMass;
    }

    public string GetName()
    {
        return _name;
    }

    public abstract string GetFormula();
}