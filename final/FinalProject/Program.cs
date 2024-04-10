using System;

class Program
{
    string FILENAME = "data";
    static void Main(string[] args)
    {
        Kitchen kitchen = new Kitchen();

        List<string> options = ["SaveKitchen", "LoadKitchen", "ChooseRecipe"];
        Menu<string> main = new Menu<string>(options);
        while (true)
        {
            main.MethodMenu("get_Name", kitchen, true, options.ToArray());
        }
    }
}