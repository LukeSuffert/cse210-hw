using System;
using System.Collections.Generic;

namespace classes_demo
{
    public class Reflection : Activity
    {
        private List<string> _prompts = new List<string>();
        private List<string> _questions = new List<string>();
        private Random _random = new Random();

        public Reflection() : base ("Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        {
            _prompts.Add("Think of a time when you stood up for someone else.");
            _prompts.Add("Think of a time when you did something you thought you weren't able to.");
            _prompts.Add("Think of a time when you decided to be honest.");
            _prompts.Add("Think of a time when you made someone happy.");

            _questions.Add("Why was this experience meaninngul to you?");
            _questions.Add("What made you take the decision to act this way?");
            _questions.Add("How did you feel when it was done?");
            _questions.Add("What could you learn from that experience?");
            _questions.Add("How did that make you closer to the Savior?");
            _questions.Add("Is there anything you would have done differently in that situation?");
            _questions.Add("How can you keep this experience in mind in the future");
        }

        private string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }

        private string GetRandomQuestion()
        {
            int index = _random.Next(_questions.Count);
            return _questions[index];
        }

        public void Run()
        {
            WelcomeMessage();
            Console.WriteLine();

            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine();

            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.WriteLine();

            Console.WriteLine("Now ponder the following questions:");
            Spinner();

            DateTime endTime = DateTime.Now.AddSeconds(_timer);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine(GetRandomQuestion());
                Spinner();
            }

            EndMessage();
        }
    }
}
