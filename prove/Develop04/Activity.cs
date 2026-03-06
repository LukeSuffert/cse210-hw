using System;
using System.Threading;


namespace classes_demo
    {
public class Activity
{
    protected string _activityName = "";

    protected string _instruction = "";

    protected int _timer;

    public Activity(string activityname, string instruction)
    {
        _activityName = activityname;
        _instruction = instruction;
    }


    public void WelcomeMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine(_instruction);

        Console.Write("Enter duration in seconds: ");
        _timer = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
        Thread.Sleep(2000);
        Spinner();
    }

    public void EndMessage()
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You completed the {_activityName} activity for {_timer} seconds!");
            Spinner();
        }

    public void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        public void Spinner()
        {
            string[] spin = {"|", "/", "-", "\\"};

            for (int i = 0; i < 10; i++)
            {
                Console.Write(spin[i % 4]);
                Thread.Sleep(200);
                Console.Write("\b");
            }
        }

    public string GetActivityName()
    {
        return _activityName;
    }

    public string GetInstruction()
    {
        return _instruction;
    }


}

}
