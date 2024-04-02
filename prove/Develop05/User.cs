using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Reflection.Metadata;
using Util = Utility;


class User
{
    private string _name;
    private int _score;
    private List<Goal> _goals;

//constructor
    public User()
    {
        Util.FancyS("Now creating a new user...");
        Thread.Sleep(1000);
        string nameAttempt = "";
        int i = 0;
        while (true)
        {
            if (i > 3)
            {
                Util.FancyS("To many failed attempts. Exiting now.");
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            Util.FancyS("What is your name? => ");
            nameAttempt = Console.ReadLine();
            if (CheckUserName(nameAttempt))
            {
                break;
            }
            else
            {
                Util.FancyS("Username does not exist. Please try again.");
            }
            i++;
        }
        
        this._name = nameAttempt;
        this._score = 0;
        this._goals = new List<Goal>();
    }

    public User(string name, int score)
    {
        this._goals = new List<Goal>();
        this._name = name;
        this._score = score;
        LoadGoals();
    }


//getters+setters
    public string UserName
    {
        get {return _name;}
    }
        
    public int Score
    {
        get {return _score;}
        set {_score = value;}
    }

    public List<Goal> Goals
    {
        get {return _goals;}
        set {_goals = value;}
    }
    
/// <summary>
/// Saves the users goals to a file.
/// <para>
/// Runs the native "serialize" method of each goal in the list to fetch the information to be saved
/// </para>
/// </summary>
    public void SaveGoals()
    {   
        if (_goals.Count < 1)
        {
            return;
        }

        List<string> serialized = new List<string>();
        foreach (Goal goal in this.Goals)
        {
            string line = goal.Serialize();
            serialized.Add(line);
        }
        string fileName = "./UserData/" + this._name + "Goals.txt";
        
        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            for (int i = 0; i < serialized.Count; i ++)
            {
                outputFile.WriteLine(serialized[i]);
            }
        }
        this.SaveUser();
    }

/// <summary>
/// Checks if a file exists for the current user. If no, notifies the user that they do not currently have a set of goals. If yes, loads the goals from the users file. 
/// </summary>
/// <param name="name"></param>
    public void LoadGoals()
    {
        
        string fileName = "./UserData/" + this._name + "Goals.txt";

        string[] lines = System.IO.File.ReadAllLines(fileName);
        

        //The ONLY types currently are Simple, Eternal, Checklist
        List<Goal> temp = new List<Goal>();
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            Array.Resize(ref parts, 7);

            string[] typeName = parts[0].Split(":");

            string type = typeName[0].Trim();
            string name = typeName[1].Trim();

            string description = parts[1].Trim();
            int points = int.Parse(parts[2].Trim());
            bool completion =  bool.Parse(parts[3].Trim());
            int target = 0;
            int bonus = 0;
            int current = 0;
            if (int.TryParse(parts[4], out int result))
            {
                target = result;
            }
            if (int.TryParse(parts[5], out int echo))
            {
                bonus = echo;
            }
            if (int.TryParse(parts[6], out int alpha))
            {
                current = alpha;
            }
            
            

            switch (type)
            {
                case "Simple":
                    temp.Add(new Simple(name, description, points, completion));
                    break;
                case "Eternal":
                    temp.Add(new Eternal(name, description, points));
                    break;
                case "Checklist":
                    temp.Add(new Checklist(name, description, points, completion, target, bonus, current));
                    break;
            }
            this.Goals = temp;
        }
    }
    
    public static User LoadUser()
    {
        User user;
        while (true)
        {    
            string fileName = "./UserData/UserList.txt";
            
            if (File.Exists(fileName))
            {
                Util.FancyS("Please enter a user name or type new user=> ");
                string userName = Console.ReadLine().Trim();
                userName = userName.ToLower();
                if (userName == "new user")
                {
                    user = new User();
                    return user;
                }
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    if (line.Contains(userName))
                    {
                        Console.WriteLine("User Found");
                        string[] parts = line.Split(",");
                        user = new User(parts[0], int.Parse(parts[1].Trim()));
                        return user;
                    }
                    
                }
            }
            else
            {
                Util.FancyS("There are currently no users.");
                user = new User();
                return user;
            }
        }
        // return user;
        
    }

    public void SaveUser()
    {
        string fileName = "./UserData/UserList.txt";
        if (File.Exists(fileName))
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i ++)
            {
                if (lines[i].Contains(this.UserName))
                {
                    string[] parts = lines[i].Split(",");
                    parts[0] = parts[0].Trim();
                    parts[1] = this.Score.ToString();
                    lines[i] = string.Join(", ", parts);
                }
            }
            using (StreamWriter w = new StreamWriter (fileName))
            {
                foreach (string line in lines)
                {
                    w.WriteLine(line);
                }
            }
        }
        else
        {
            using (StreamWriter w = new StreamWriter(fileName))
            {
                w.Write(this.UserName.Trim() + ", " + this.Score);
            }
        }
        Util.FancyS("User data has been saved!");
        Thread.Sleep(500);

    }

    public static bool CheckUserName(string input)
    {
        string fileName = "./UserData/UserList.txt";
        bool available = true;

        if (File.Exists(fileName))
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            
            foreach (string line in lines)
            {
                if (line.Contains(input))
                {
                    available = false;
                    return available;
                }
            }
            
        }
        return available;
    }

/// <summary>
/// Updates the member variable  "_score" by adding the parameter "points".
/// <para>
/// Intended to be implemented after a goal is completed.
/// </para>
/// </summary>
/// <param name="points">Integer Input</param>
    public void UpdateScore(int points)
    {
        //this. notation makes it easier for me to read
        this.Score += points;
    }

    public void RecordEvent()
    {
        List<string> names = new List<string>();
        for (int i = 0; i < Goals.Count; i++)
        {
            string echo = _goals[i].Name;
            names.Add(echo);
        }
        Menu<string> goalNames = new Menu<string>(names); 

        int selection = goalNames.DisplayMenu("Name");
        int score = this.Goals[selection-1].RecordEvent();
        this.UpdateScore(score);
    }

    public void ListGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            Util.FancyS($"\n{i + 1}. ", false);
            _goals[i].DisplayGoal();
        }
        Console.WriteLine("\n");
    }

/// <summary>
/// Updates the "_goals" member variable of the User class. Meant to be called every time a new Goal is created.
/// </summary>
/// <param name="goals">A list of goal objects</param>
    public void UpdateGoals(List<Goal> goals)
    {
        this.Goals = goals;
    }

    public void NewGoal()
    {
        Menu<string> menu = new Menu<string>(new List<string>{"Simple", "Eternal", "Checklist"});
        int index = menu.DisplayMenu("Callconstructor");
        string choice = menu.Options[index - 1];
        Goal instance;
        switch (choice)
        {
            case "Simple":
                instance = new Simple(); 
                this.Goals.Add(instance);
                break;
            
            case "Eternal":
                instance = new Eternal();
                this.Goals.Add(instance);
                break;
            case "Checklist":
                instance = new Checklist();
                this.Goals.Add(instance);
                break;

        }
        
    }
}

