using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Xml.Serialization;


static class Utility
{
    //Only takes the input of a number
    public static int IntegerInput(int? provided = null)
    {
        string input;
        int output = 0;

        while (true)
        {   
            input = Console.ReadLine();

            if (int.TryParse(input, out output))
            {
                break;
            }
            else
            {
                IncramentalString("Invalid input. Please enter a valid integer:", false);
            }
        }
        return output;
    }

    //Will clear and write to the console character by character from an input string
    //Clearing is optional with the additional paramenter 'noclear'. any number will stop the console clear
    public static void IncramentalString(string starting, bool? clear = null)
    {   
        if (!clear.HasValue)
        {
                Console.Clear(); // will only clear the console if 'clear' is set to 'false'  or not provided at all
        }
        
        foreach (char r in starting)
        {
            Console.Write(r);
            Thread.Sleep(20);
        }
    }

    
}

