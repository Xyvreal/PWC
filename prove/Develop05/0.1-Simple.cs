using System;

class Simple : Goal
{
    public Simple(string name, string description, int points, bool completion)
        : base(name, description, points, completion)
        {}
    public Simple() : base()
    {

    }
    public override string Serialize()
    {
        List<string> data = new List<string>();
        data.Add("Simple : " + this.Name);
        data.Add(this.Description);
        data.Add(this.Points.ToString());
        data.Add(this.Completion.ToString());
        string newLine = string.Join(", ", data);
        return newLine;
    }
}