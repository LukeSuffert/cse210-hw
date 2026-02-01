using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            // Display menu

            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                // Write
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                // Display
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Load
                Console.Write("Enter the filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
                Console.WriteLine("Nice! Journal loaded successfully!");
            }
            else if (choice == "4")
            {
                // Save
                Console.Write("Enter the filename to save to: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
                Console.WriteLine("Nice! Journal saved successfully.");
            }
            else if (choice == "5")
            {
                // Quit
                Console.Write("See you later!");
                running = false;
            }
            else
            {
                // Invalid input
                Console.WriteLine("Not that silly human user. Please select 1-5.");
            }
        }
    }
}
