using System;
public class Reflecting : Activity
{
   
    private List<string> _prompts = new List<string>() 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>() 
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?"
    };
    
    public Reflecting () 
        : base ("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
            
        }


    public override void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        DateTime startTime = DateTime.Now;
        DateTime targetTime = startTime.AddMilliseconds(this.Duration); // 'this.' to improve readability for me
        while (startTime < targetTime)
        {
            DisplayQuestions();
            startTime = DateTime.Now;
        }
        DisplayEndingMessage();
    }

    public void DisplayQuestions()
    {
        string question = GetRandomQuestion();
        Utility.IncramentalString(question + "\n", false);
        ShowSpinner(5);
    }

    public void GetRandomPrompt()
    {
        Random rand = new Random();
        int randomPrompt = rand.Next(_prompts.Count);
        string randomText = _prompts[randomPrompt];
        Utility.IncramentalString(randomText);
        Utility.IncramentalString("\nPlease think about the above prompt. The activity will begin shortly... \n", false);
        ShowCountDown(3);
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        int randomPrompt = rand.Next(_questions.Count);
        string randomText = _questions[randomPrompt];
        
        return randomText;
    }
} //    |/-\|/-\|