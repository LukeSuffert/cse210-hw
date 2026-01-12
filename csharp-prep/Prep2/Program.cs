using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What was your percentage grade? ");
        int percentage = int.Parse(Console.ReadLine());

        string letter = "";

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your final grade is: {letter} ");

        if (percentage >= 70)
        {
            Console.WriteLine("Wow, wonderful job! You passed the class!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the class, you got it next time though!");
        }
    }
}