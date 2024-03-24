using System;
using System.Configuration.Assemblies;
using System.Numerics;
/*
Notice:
Filenames do not match class exactly as I opted to try naming 
each class and subcalss group in a way that makes it easy to see 
the Inheritance Hierarchy.
*/

public interface IActivity
{
    void Run();
}
public class Activity : IActivity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public int Duration
    {
        get {return _duration;}
    }

    public string Name
    {
        get {return _name;}
    }


    public virtual void Run()
    {

    }


//Displays the name and description of the activity then asks and sets the duration of the activity. 
    public void DisplayStartingMessage()
    {
        
        string startMessage1 = $"Welcome to the {_name.ToLower()} activity!\n\n{_description}";
        string startMessage2 = $"\n\nHow long, in seconds, would you like your session to be? => "; //seperated for better readability
        Utility.IncramentalString(startMessage1 + startMessage2);
        _duration = Utility.IntegerInput() * 1000;
        Utility.IncramentalString("Get ready... ");
        ShowSpinner(3);

    }

//Displays the name and duration that the activity was procticed and pauses the program for three seconds.
    public void DisplayEndingMessage()
    {
        
        Utility.IncramentalString("Well Done!  ");
        ShowSpinner(3);
        Utility.IncramentalString($"\n\nYou have completed {_duration/1000} seconds of the {_name} activity. ", false);
        ShowSpinner(3);
    }

//Spinning Animation
    public void ShowSpinner(int seconds)
    {
        string[] frames = {"|", "/", "-", "\\", "|", "/", "-", "\\"};
        int miliSec = seconds * 1000;
        int target = miliSec/100;
        int iterations = 0; 
        int index = 0;
        while (iterations < target)
        {
            Console.Write(frames[index]);
            Thread.Sleep(100);
            index = (index + 1) % frames.Length;
            Console.Write("\b \b");
            iterations ++;
        }

    }

//Counts down in seconds
    public void ShowCountDown(int starting)
    {
        while (starting > 0)
        {
            Console.Write(starting);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            starting --;
        }
    }
    


}

