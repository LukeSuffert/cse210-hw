using System;
using System.Collections.Generic;

namespace classes_demo
{
    class Listing : Activity
    {
        private List<string> _prompts = new List<string>();
        private List<string> _items = new List<string>();
        private Random _random = new Random();

        private List<string> _unusedPrompts = new List<string>();

        public Listing() : base("Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts.Add("Who are people that make you smile?");
            _prompts.Add("What are your favorite foods?");
            _prompts.Add("What things bring you the Holy Spirit?");
            _prompts.Add("What cartoons did you like to watch as a kid?");
            _prompts.Add("What parts of your routine do you appreciate the most?");
        }

        private string GetRandomPrompt()
        {
            if (_unusedPrompts.Count == 0)
            {
                _unusedPrompts = new List<string>(_prompts);
            }

            int index = _random.Next(_unusedPrompts.Count);
            string prompt = _unusedPrompts[index];

            _unusedPrompts.RemoveAt(index);

            return prompt;
        }

        public void Run()
        {

            WelcomeMessage();

            _unusedPrompts = new List<string>(_prompts);

            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine("Starting in:");
            Countdown(5);

            DateTime endTime = DateTime.Now.AddSeconds(_timer);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                _items.Add(Console.ReadLine());
            }

            Console.WriteLine($"You listed {_items.Count} items.");

            EndMessage();
        }
    }
}