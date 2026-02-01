using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // List and Random
    private List<string> _prompts;
    private Random _random;

    // Prompts
    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>();

        _prompts.Add("What was the funniest thing that happened today?");
        _prompts.Add("What was the most spiritual experience you had today?");
        _prompts.Add("What were you most excited about today?");
        _prompts.Add("What was the strongest emotion you felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    // Getting a Random Prompt
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}

