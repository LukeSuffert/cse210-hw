using System;
using classes_demo;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Timmy", "Algebra");
        Console.WriteLine(assignment1.GetSummary());

        classes_demo.Math assignment2 = new classes_demo.Math("Kyle", "Division", "4.4", "1-10");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("George Martin", "Mitochondria", "An insight in cellular composition");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInfo());

    }
}