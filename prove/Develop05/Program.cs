using System;
using System.Collections.Generic;
using System.IO;
using classes_demo;

class Program
{
    static int _totalPoints = 0;
    static List<Goal> _goals = new List<Goal>();

    static void Main()
    {
        ShowMenu();
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine($"You have {_totalPoints} points.");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            string option = Console.ReadLine();
            Console.WriteLine();

            if (option == "1")
            {
                CreateGoal();
            }
            else if (option == "2")
            {
                ListGoals();
            }
            else if (option == "3")
            {
                SaveGoals();
            }
            else if (option == "4")
            {
                LoadGoals();
            }
            else if (option == "5")
            {
                RecordEvent();
            }
            else if (option == "6")
            {
                Console.WriteLine("See you later!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice! Please select a number between 1 and 6.");
                Console.WriteLine();
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (bad habit)");

        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }

        else if (goalType == "4")
            {
                NegativeGoal goal = new NegativeGoal(name, description, points);
                _goals.Add(goal);
            }

        Console.WriteLine("Goal created successfully!");
        Console.WriteLine();
    }

    static void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.WriteLine();
    }

    static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        int earnedPoints = _goals[choice].RecordEvent();
        _totalPoints += earnedPoints;

        Console.WriteLine($"You earned {earnedPoints} points!");
        Console.WriteLine($"You now have {_totalPoints} points.");
        Console.WriteLine();
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_totalPoints);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
        Console.WriteLine();
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        _totalPoints = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("|");

            string type = parts[0];

            if (type == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                SimpleGoal goal = new SimpleGoal(name, description, points);
                _goals.Add(goal);
            }
            
            else if (type == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }

            else if (type == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int current = int.Parse(parts[5]);
                int target = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);

                _goals.Add(goal);
            }

            else if (type == "NegativeGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    NegativeGoal goal = new NegativeGoal(name, description, points);
                    _goals.Add(goal);
                }
        }

        Console.WriteLine("Goals loaded successfully.");
        Console.WriteLine();
    }
}