using System;
using System.Diagnostics.CodeAnalysis;

class Fruit : Ingredient
{

    public Fruit() : base()
    {}
    public override void CheckFresh()//Special fruits that are only bad if they smell bad. Truely unfortunate for those who do not have a sense of smell. 
    {
        while (true)
        {
            Utility.FancyS("Does it smell bad?");
            string input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
                Utility.FancyS("It's rotten, you can't use it.");
                this.Fresh = false;
                break;
            }
            else if (input.ToLower() == "no")
            {
                Utility.FancyS("It's fresh, you can use it.");
                this.Fresh = true;
                break;
            }
            else
            {
                Utility.FancyS("Please enter 'yes' or 'no.");
            }
        }
        
    }
}