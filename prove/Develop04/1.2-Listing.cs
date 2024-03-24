using System;
using System.ComponentModel.DataAnnotations;

public class Listing : Activity, IActivity
{
    private int _count;

    private List<string> _response;
    

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public Listing () 
        : base ("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        
         this._response = new List<string>();
         _count = 0;


    }

    public override void Run()
    {
        DisplayStartingMessage();

        GetRandomPrompt();

        DateTime startTime = DateTime.Now;
        DateTime targetTime = startTime.AddMilliseconds(this.Duration); // 'this.' to improve readability for me
        while (startTime < targetTime)
        {
            GetListFromUser();
            startTime = DateTime.Now;
        }
        _count = _response.Count;
        Utility.IncramentalString($"You entered {_count} items for this prompt.\n\n");
        ShowSpinner(3);
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random rand = new Random();
        int randomPrompt = rand.Next(_prompts.Count);
        string randomText = _prompts[randomPrompt];
        Utility.IncramentalString(randomText+"\n");
        Utility.IncramentalString("Please think about the above prompt. The activity will begin shortly... ", false);
        ShowCountDown(5);
    }

    public void GetListFromUser()
    {
        Console.Write("\n=> ");
        string answer = Console.ReadLine();
        _response.Add(answer);        
    }
}