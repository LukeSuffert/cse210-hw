using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int mnumber = randomGenerator.Next(1,100);

        Console.Write("What is your guess? ");
         int guess = int.Parse(Console.ReadLine());


         while (guess != mnumber)
        {
        if (mnumber > guess)
        {
            Console.WriteLine("Higher"); 
            Console.Write("What is your guess? ");
         guess = int.Parse(Console.ReadLine());
        }
        if (mnumber < guess)
        {
           Console.WriteLine("Lower");
           Console.Write("What is your guess? ");
         guess = int.Parse(Console.ReadLine());
        }

        } 

        Console.WriteLine("You guessed it!");
    }
}