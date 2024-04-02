using System;
using System.Reflection;

static class Utility
{
    //Only takes the input of a number
    public static int IntIn()
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
    public static void FancyS(string starting, bool clear = true)
    {   
        if (clear == true)
        {
                Console.Clear(); // will only clear the console if 'clear' is set to 'false'  or not provided at all
        }
        
        foreach (char r in starting)
        {
            Console.Write(r);
            Thread.Sleep(10);
        }
    }
    
    public static TResult GenericMethod<T, TResult>(T obj, string methodName, params object[] parameters)
    {
        MethodInfo method = typeof(T).GetMethod(methodName);

        return (TResult)method.Invoke(obj, parameters);
    }

    public static void GenericVoidMethod<T>(T obj, string methodName, params object[] parameters)
        {

            MethodInfo method = typeof(T).GetMethod(methodName);
            // Type type = 
            method.Invoke(obj, parameters);
        }
    
    public static void CallConstructor(string className, params object[] parameters)
    {
        //generic method to accept any type of class
        Type type = Type.GetType(className); //checks the class type to pass to the createinstance method
        object instance = Activator.CreateInstance(type, parameters); //Activator is in the system namespace. Used to create instances of types
                                                                    // and retreiving info about types
    }
}

