using System.Runtime.CompilerServices;

class Orca : Animal
{
    public Orca(string n) : base(n)
    {
        
    }

    public void MakeNoise()
    {
        Console.WriteLine("Clickety Click Click!");
    }

}