using System;
using System.ComponentModel;
using Util = Utility;

/// <summary>
/// Parent class for evey kind of goal. Contains the goal methods:
/// <para>
/// Name (string)
/// </para>
/// <para>
/// Description (string)
/// </para>
/// <para>
/// Point Value (int)
/// </para>
/// <para>
/// Completion status (bool)
/// </para>
/// </summary>
abstract class Goal
{
    private string _name;
    private string  _description;
    private int _points;
    private bool _completion;

/// <returns>
/// Passes the value of the private <emphasis>integer</emphasis> member "_points"
/// </returns>
/// <value>
/// Any integer to represent how many points the goal will be worth
/// </value>
    protected int Points
    {
        get {return _points;}
        set {_points = value;}
    }

/// <returns>
/// Passes the value of the private <emphasis>string</emphasis> member "_name"
/// /// </returns>
    public string Name
    {
        get {return _name;}
    }

/// <returns>
/// /// Passes the value of the private <emphasis>string</emphasis> member "_description"
/// </returns>
    public string Description
    {
        get {return _description;}
    }

/// <returns>
/// Passes the value of the private <emphasis>bool</emphasis> member "_completion"
/// </returns>
    public bool Completion
    {
        get {return _completion;}
        set {_completion = value;}
    }

    
/// <summary>
    /// Initializes a new goal object by asking the user for the goals name, description, and point value.
    /// Automatically sets the goals completion status to false. 
    /// </summary>
    public Goal()
    {
        this._completion = false;

        Util.FancyS("\nPlease provide a short name for your goal. => ", false);
        this._name = Console.ReadLine();

        Util.FancyS("\nPlease write a short description of the goal. => ", false);
        this._description = Console.ReadLine();

        Util.FancyS("\nHow many points will this goal award upon completion? => ", false);
        this._points = Util.IntIn();
        
    }

    public Goal(string name, string description, int points, bool completion)
    {
        this._name = name;
        this._description = description;
        this._points = points;
        this._completion = completion;
    }

/// <summary>
    ///Method used to update the completion status of the goal and return pont value of the goal. 
    ///<para>
    ///Changes  the "_completion" member from "false" to "true" by default
    ///</para>
    ///</summary>
    ///<returns>An integer equal to the value of the Goal.</returns>
    public virtual int RecordEvent()
    {
        _completion = true;
        return Points;
    }
    
    public abstract string Serialize();

    public virtual void DisplayGoal()
    {
        string completionMark = " ";
        if (Completion == true)
        {
            completionMark = "X";
        }
        Utility.FancyS($"[{completionMark}]. {this.Name} -- ({this.Description})", false);
    }

}