using System;

public class Entry
//Made up of date - prompt - response and stored as such
//Gets a random prompt from the list of _prompts
//Function to get user input and store it into a string
//Function to get the date and store it into a string
{
    private List<string> _prompts;
    public string _prompt;
    public string _response;
    public string _date;
    
    public Entry()
    {
        initaliizePrompt();

        DateTime theCurrentTime = DateTime.Now;
        string dateToday = theCurrentTime.ToShortDateString();
        _date = dateToday;
    }
    public Entry(string response)
    {
        initaliizePrompt();

        DateTime theCurrentTime = DateTime.Now;
        string dateToday = theCurrentTime.ToShortDateString();
        _date = dateToday;

        _response = response;
    }

    public Entry(string response, string date)
    {
        initaliizePrompt();

        _date = date;
        _response = response;
    }

    public Entry(string response, string date, string prompt)
    {
        _prompt = prompt;
        _date = date;
        _response = response;
    }

    private void initaliizePrompt()
    {
        _prompts = new List<string>{"What was your favorite part of the day?",
                            "What would you like to do better at tomorrow?",
                            "How have you served others today?", 
                            "Do you need to forgive anyone today?",
                            "Is your current lifestyle making you happy?",
                            "What are your current priorities and are you following them?"};
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        _prompt = _prompts[index];
    }

    public string GetResponse()
    {
        Console.Write(">");
        string output = Console.ReadLine();
        return output; 
    }

}