using System;

public class Kitchen
{
    private List<Recipe> _cookbook;
    private Pantry _pantry;

    public Kitchen()
    {}
    public Kitchen(string filename)
    {

    }   

    public void SaveKitchen() 
    {
        Utility.FancyS("Kitchen saved.\n");
        Thread.Sleep(2000);
    }
    public void LoadKitchen() 
    {
        Utility.FancyS("Kitchen loaded.\n");
        Thread.Sleep(2000);
    }
    // public List<Recipe> MakeableRecipies() 
    // {
    //     List<Recipe> recipes = new List<Recipe>();

    //     return recipes;
    
    // }
    public void ChooseRecipe() 
    {
        Utility.FancyS("No Recipies to choose.\n");
        Thread.Sleep(2000);
    }
    public void AllRecipies() 
    {
        
    }
}


// Private List<Recipe> _cookbook;
// Private Pantry _pantry;

// Kitchen();
// Kitchen(string filename);

// Public Void SaveKitchen(Filename);
// Public Void LoadKitchen(Filename);
// Public List<Recipe> MakeableRecipies();
// Public void ChooseRecipie();
// Public void AvailableRecipies();
