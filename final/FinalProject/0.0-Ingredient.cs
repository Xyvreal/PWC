using System;

class Ingredient
{
    private string _name;
    private int _storeTemp;
    private string _humididty;
    private bool _fresh;
    private DateTime _aquasition;

    public Ingredient()
    {
        Utility.FancyS("What is the name of the ingredient?\n=> ");
        this._name = Console.ReadLine();
        Utility.FancyS("What temperature should the ingredient be stored at?\n=> ");
        this._storeTemp = Utility.IntIn();
        this._fresh = true;
        Utility.FancyS("What humidity should the ingredient be stored at?\n=> ");
        this._humididty = Console.ReadLine();
        this._aquasition = DateTime.Now;
    }
    public Ingredient(string name, int storeTemp, string humidity, DateTime aquasition)
    {

    }

    protected bool Fresh
    {
        get {return _fresh;}
        set {_fresh = value;}
    }

    public virtual void CheckFresh()
    {
        DateTime today = DateTime.Now;
        TimeSpan difference = today.Subtract(_aquasition);
        if (difference.TotalDays > 7)
        {
            this._fresh = false;
        }
    }
}