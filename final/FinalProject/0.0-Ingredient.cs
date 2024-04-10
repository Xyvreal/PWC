using System;

class Ingredient
{
    private string _name;
    private int _storeTemp;
    private string _humididty;
    private bool _fresh;
    private DateTime aquasition;

    public Ingredient()
    {

    }
    public Ingredient(string name, int storeTemp, string humidity, DateTime aquasition)
    {

    }

    public virtual void CheckFresh()
    {
        
    }
}