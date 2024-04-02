using System;
using System.Data.Common;

class Checklist : Goal
{
    private int _target;
    private int _bonus;

    private int _current;
    
    public Checklist()
        : base()
    {
        Utility.FancyS("\nPlease input how many times you would like to complete this goal. => ", false);
        this._target = Utility.IntIn();
        Utility.FancyS($"\nPlease input how may points sould be awarded after completing the goal {this._target} times. => ", false);
        this._bonus = Utility.IntIn();
    }
    public Checklist(string name, string description, int points, bool completion, int target, int bonus, int current)
        : base (name, description, points, completion)
    {
        this._target = target;
        this._bonus = bonus;
        this._current = current;
    }

    public override string Serialize()
    {
        List<string> data = new List<string>();
        data.Add("Checklist :" + this.Name);
        data.Add(this.Description);
        data.Add(this.Points.ToString());
        data.Add(this.Completion.ToString());
        data.Add(this._target.ToString());
        data.Add(this._bonus.ToString());
        data.Add(this._current.ToString());
        string newLine = string.Join(", ", data);
        return newLine;
    }

    public override int RecordEvent()
    {
        if (this._target == this._current)
        {
            this.Completion = true;
            return Points + this._bonus;
        }
        else
        {
            _current ++;
            return Points;
        }
    }

    public override void DisplayGoal()
    {
        string completionMark = " ";
        if (Completion == true)
        {
            completionMark = "X";
        }
        Utility.FancyS($"[{completionMark}]. {this.Name} -- ({this.Description}) -- Currently Completed ({_current}/{_target})", false);
    }
}