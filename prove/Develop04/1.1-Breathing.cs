using System;
using System.Runtime.CompilerServices;

public class Breathing : Activity
{
    public Breathing () 
        : base ("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing")
    {
        //no additional fields
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime targetTime = startTime.AddMilliseconds(this.Duration); // 'this.' to improve readability for me
        while (startTime < targetTime)
        {
            Utility.IncramentalString("\nBreath in... ");
            ShowCountDown(3);
            Utility.IncramentalString("\nHold... ");
            ShowCountDown(3);
            Utility.IncramentalString("\nNow breathe out slowly... ");
            ShowCountDown(4);
            startTime = DateTime.Now;
        }

        DisplayEndingMessage();    
    }
}

