using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Serialization;


static class Utility
{
    //Only takes the input of a number
    public static int IntIn(int? provided = null)
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
                FancyS("Invalid input. Please enter a valid integer:", false);
            }
        }
        return output;
    }

    //Will clear and write to the console character by character from an input string
    //Clearing is optional with the additional paramenter 'noclear'. any number will stop the console clear
    public static void FancyS(string starting, bool clear = false)
    {   
        if (clear == true)
        {
                Console.Clear(); // will only clear the console if 'clear' is set to 'true'  or not provided at all
        }
        
        foreach (char r in starting)
        {
            Console.Write(r);
            Thread.Sleep(20);
        }
    }

    public static void VoidMethod(object target, string methodName, params object[] parameters)
    {
        Type type = target.GetType();
        MethodInfo method = type.GetMethod(methodName);
        method.Invoke(target, parameters);
    }
    public static object ReturnMethod(object target, string methodName, params object[] parameters)
    {
        Type type = target.GetType();
        MethodInfo method = type.GetMethod(methodName);
        return method.Invoke(target, parameters);
    }

    
}

