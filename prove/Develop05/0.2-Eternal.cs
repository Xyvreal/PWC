using System;

class Eternal : Goal
{
    public Eternal(string name, string description, int points)
        : base(name, description, points, false)
        {}

    public Eternal() : base()
    {

    } 
    public override string Serialize()
    {
        List<string> data = new List<string>();
        data.Add("Eternal :" + this.Name);
        data.Add(this.Description);
        data.Add(this.Points.ToString());
        data.Add(this.Completion.ToString());
        string newLine = string.Join(", ", data);
        return newLine;
    }

    public override int RecordEvent()
    {
        return Points;
    }
    public override void DisplayGoal()
    {
        Utility.FancyS($"[ ]. {this.Name} -- ({this.Description})", false);
    }
}