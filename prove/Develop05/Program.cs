using System;

/*
For this assugnment, I exceeded expectations through the following:
    1. Started to implemented xml documentation in my methods to improve readability and ease of use (got tired of looking across files for method info)
    2. Allowed multiple users to use the program with seperatly stored data through the user class that saves, loads and passes on all user info from a file. 
    3. Learned implemented Genaric Types and methods. (moderatly successfull -- still in progress)
        - best examples in the base Goal class
    4. Overloaded a method using params
    5. Save the information to automatically set files [both located in the UserData directory] (Userlist.txt and "{username}+Goals.txt") so the user doesnt have to type it in. 
        Files also load outomatically upon "login"

I learned alot going through this assignment but am dissatisfied with my code. I attempted to imnplement things as i learned them but ended up 
straying too far from my initial plan. This made programming the rest of the assignment much more difficult as parts that I initially expected
were changed too much to initially flow with the rest of the program.
The biggest lesson from this experience was to keep a dynamic outline of the code that I change as I think i may want to make changes. This will
ensure that all parts of my program flow together nicely. 
*/
class Program
{
    static void Main(string[] args)
    {
        User client = User.LoadUser();

        List<string> mainOptions = new List<string>() {"Create New Goal", "List Goals", "Save Goals", "Record Event"};
        string[] optionEffects = {"NewGoal","ListGoals",  "SaveGoals",  "RecordEvent"};

       

        while (true)
        {

            Utility.FancyS($"You have {client.Score} points.\n\n", false);
            Menu<string> main = new Menu<string>(mainOptions);
            int index = main.DisplayMenu("ProvidedInstance", true, optionEffects);
            Utility.GenericVoidMethod(client, optionEffects[index - 1]);
        }
    }
}