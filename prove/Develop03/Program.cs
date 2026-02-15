using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Luke", 10, 25, 28);


        string text = "¶ And, behold, a certain lawyer stood up, and tempted him, saying, Master, what shall I do to inherit eternal life? 26 He said unto him, What is written in the law? how readest thou? 27 And he answering said, Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy strength, and with all thy mind; and thy neighbour as thyself. 28 And he said unto him, Thou hast answered right: this do, and thou shalt live.";

        Scripture scripture = new Scripture(reference, text);


        Console.WriteLine("Choose memorizaton method: ");
        Console.WriteLine("1 - Normal Hiding");
        Console.WriteLine("2 - First Letter Mode: ");
        Console.Write("Enter choice 1 or 2: ");

        string choice = Console.ReadLine();

        DisplayMode mode = DisplayMode.Normal;

        if (choice == "2")
        {
            mode = DisplayMode.FirstLetter;
        }

        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText(mode.ToString()));

            if (mode == DisplayMode.Normal && scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();


            if (input != null && input.ToLower() == "quit")
            {
                break;
            }

            if (mode == DisplayMode.Normal)
            {
                scripture.HideRandomWords(3);
            }


        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText(mode.ToString()));
        Console.WriteLine("\nProgram ended. Now try to quote the scripture from your head!");
    }
}