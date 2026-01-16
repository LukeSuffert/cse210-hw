using System;
using System.Configuration.Assemblies;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        DisplayWelcome();

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Enter your favorite number in the whole Universe: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
    

        static void PromptUserBirthYear(out int year)
        {
            Console.Write("Enter the year you were born: ");
            year = int.Parse(Console.ReadLine());
        }

        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        static void DisplayResult(string name, int square, int year)
        {
            Console.WriteLine($"{name}, the square of your number is {square}.");
            Console.WriteLine($"{name}, you will turn {2026 - year} this year.");
        }

        string name = PromptUserName();
        int number = PromptUserNumber();
        PromptUserBirthYear(out int year);
        int square = SquareNumber(number);
        DisplayResult(name, square, year);
    }
}