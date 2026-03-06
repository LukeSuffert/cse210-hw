using System;
using classes_demo;

class Program
{
    static void Main()
    {
        ShowMenu();
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.WriteLine("Select a choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Breathing activity = new Breathing();
                activity.Run();
                Console.WriteLine();
            }

            else if (choice == "2")
            {
                Reflection activity = new Reflection();
                activity.Run();
                Console.WriteLine();
            }

            else if (choice == "3")
            {
                Listing activity = new Listing();
                activity.Run();
                Console.WriteLine();
            }

            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice! Please select a number between 1 and 4.");
                Console.WriteLine();
            }
        }
    }
}