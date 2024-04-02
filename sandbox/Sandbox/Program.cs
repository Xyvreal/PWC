using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
    }
}

abstract class Breakfast
{
    private int _quantity;

    private string _name;

    public Breakfast(string name, int quanity)
    {
        _name = name;
        _quantity = quanity;
    }

    public abstract void Eat(); //Allows each subclass to have this mehthod with
                                //different behaviors in each.
}

class Waffle : Breakfast 
{
    public Waffle (string name, int quantity)
        : base (name, quantity)
        {

        }

    public override void Eat()
    {
        //instuctions on how to eat a waffle. Other subclasses would 
        //hove different instructions. 

        //For an actual program requireing classes like this, I would
        //go further by splitting foods that have a similar  eating process
        //into their own subclasses then further subclassing other types of 
        //breakfasts.
    }
}

