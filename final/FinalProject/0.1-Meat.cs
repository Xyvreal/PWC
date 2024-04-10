using System;

class Meat : Ingredient
{

    public Meat() : base()
    {}

    public override void CheckFresh()// Magical meats that will never go bad
    {
        this.Fresh = true;
    }
}




