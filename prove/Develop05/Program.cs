using System;

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
            Console.WriteLine($"You have {_points} points.");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.WriteLine("Select a choice from the menu:");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine("The types of goals are:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.WriteLine("Which type of goal would you like to create?");
                string goaltype = Console.ReadLine();

                if (goaltype == "1")
                {
                    
                }

                if (goaltype == "2")
                {
                    
                }

                if (goaltype == "3")
                {
                    
                }

                Console.WriteLine();
            }

            if(option == "2")
            {
                Console.WriteLine();
            }

            if(option == "3")
            {
                Console.WriteLine();
            }

            if(option == "4")
            {
                Console.WriteLine();
            }

            if(option == "5")
            {
                Console.WriteLine();
            }

            if(option == "6")
            {
                Console.WriteLine("See you later!");
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