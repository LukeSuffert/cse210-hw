using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Noise Maker!");
        Animal.myAnimal = new Animal("Dave");
        myAnimal.MakeNoise();

        Orca myOrca = new Orca("Willie");
        myOrca.MakeNoise();
    }
}