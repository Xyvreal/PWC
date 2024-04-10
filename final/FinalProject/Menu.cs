using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Util = Utility;


//takes an array of names of classes that contain a 'Run' function and prints them nicely while providing and reading 
//the users choice and then executing the run function of that class. 

/// <summary>

/// </summary>
/// <typeparam name="T">"T" is any object with a method to name it and a method to execute </typeparam>
class Menu<T>
    {
        private List<T> _options;

        public Menu(List<T> list)
        {
            _options = list;
        }

        public List<T> Options
        {
            get {return _options;}
        }

        public void MethodMenu(string methodName, object target = null, bool main = false, params string[] methods)
        {
            Util.FancyS("Please choose one of the following options:\n\n");
            int number = 1;
            if (target == null)
            {
                foreach (T option in Options) 
                {
                    string optionName = Util.ReturnMethod(option, "get_Name").ToString(); //The getter for Name will always return a string
                    Util.FancyS($"{number}. {optionName}\n");
                    number++;
                }
            }
            else
            {
                foreach (string option in methods)
                {
                    string optionName = option;
                    Util.FancyS($"{number}. {optionName}\n");
                    number++;
                }
            }

            int choice;

            while (true)
            {
                choice = Util.IntIn();
                if (choice <= number)
                {
                    if ( main == true  &&  choice == number)
                    {
                        Util.FancyS("Goodbye!");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                    }
                    if (choice < 0)
                    {
                        Util.FancyS("\nPlease input one of the choices above.=> ", false);
                    }
                    if (choice > 0)
                    {
                        break;
                    }
                }

                else
                {
                    Util.FancyS("\nPlease input one of the choices above. => ", false);
                }
            }
            if (target == null)
            {
                Util.VoidMethod(Options[choice - 1], methodName);
            }
            else
            {
                Util.VoidMethod(target, methods[choice - 1]);
            }
        }

        // public void TextMenu()
        // {

        // }

    }
