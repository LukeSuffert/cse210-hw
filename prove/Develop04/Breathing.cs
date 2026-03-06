using System;

namespace classes_demo
{
    public class Breathing : Activity
    {

        public Breathing() : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
            
        }


        public void Run()
        {
        WelcomeMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_timer);

            while (DateTime.Now < endTime)
            {
            Console.WriteLine("Breathe in...");
            Countdown(4);

            Console.WriteLine("Breatheo out...");
            Countdown(4);

            }

        EndMessage();
        }

    }
}

