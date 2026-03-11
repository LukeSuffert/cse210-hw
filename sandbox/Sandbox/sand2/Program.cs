using System.Security.Cryptography;

namespace RoundShapes;

class Program
{
    static void Main(string[] args)
    {
        Circle tim = new Circle()
        tim.SetRadius(50.0);
        Console.WriteLine(tim.Area());
    }
}