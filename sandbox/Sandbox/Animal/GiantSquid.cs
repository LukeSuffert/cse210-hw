using System.Runtime;

class GiantSquid : Animal
{
    public GiantSquid(string n) : base(n)
    {
        
    }

    public override void MakeNoise()
    {
        Console.WriteLine($" I'm {_name}, no one knows what sound I make.");
    }
}