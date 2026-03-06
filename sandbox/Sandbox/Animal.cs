class Animal
{
    protected string _name;

    public Animal(string n)
    {
        _name = n;
    }

    virtual public void MakeNoise()
    {
        Console.WriteLine($"I'm {_name}, I make a Generic animal sound");
    }
}