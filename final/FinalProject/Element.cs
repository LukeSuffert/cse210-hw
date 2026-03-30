public class Element : Substance
{
    private string _symbol;
    private int _atomicNumber;

    public Element(string name, string symbol, int atomicNumber, double molarMass)
        : base(name, molarMass)
    {
        _symbol = symbol;
        _atomicNumber = atomicNumber;
    }

    public override string GetFormula()
    {
        return _symbol;
    }

    public int GetAtomicNumber()
    {
        return _atomicNumber;
    }
}