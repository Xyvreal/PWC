using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Util= Utility;


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

/// <summary>
/// Displays a menu from a list of classes and allows the user to select the option they want.
/// <para>
/// Uwes the First parameter as the method name to call a name from the instance of a class in the list.
/// </para>
/// <para>
/// Uses 'methodExec' to call the Action method of the selected menu option.
/// </para>
/// Optional parameter main is to determine if the menu should be able to exit the program or not. 
/// </summary>
/// <param name="methodName">the method name to call a name from the instance of a class in the list.</param>
/// <param name="methodExec">'methodExec' to call the Action method of the selected menu option.</param>
/// <param name="main">Optional parameter main is to determine if the menu should be able to exit the program or not.</param>
        public int DisplayMenu(string methodName, bool main = false, params string[] extraMethods)
        {
            Util.FancyS("Please choose one of the following options:\n\n", false);
            int number = 1;
            
            for (int i = 0; i < Options.Count; i ++)
            {
                T optionName = default(T);
                // if (typeof(T) != typeof(string))
                // {
                //     string returnValue = Util.GenericMethod<T, string>(Options[i], methodName);
                //     optionName = (T)Convert.ChangeType(returnValue, typeof(T));
                // }
                // else
                // {
                    optionName = (T)Convert.ChangeType(Options[i], typeof(T));
                    
                //}
                Util.FancyS($"{number}. {optionName}\n", false);
                number ++;
            }

            // foreach (T opt in _options)
            // {
            //     T optionName = default(T);
            //     if (typeof(T) != typeof(string))
            //     {
            //         string returnValue = Util.GenericMethod<T, string>(opt, methodName);
            //         optionName = (T)Convert.ChangeType(returnValue, typeof(T));
            //     }
            //     else
            //     {
            //         optionName = (T)Convert.ChangeType(opt, typeof(T));
                    
            //     }
            //     Util.FancyS($"{number}. {optionName}\n", false);
            //     number ++;
            // }
            if (main == true)
            {
                Util.FancyS($"{number}. Quit \n=> ", false);
                
            }
            else
            {
                number --;
                Util.FancyS("=> ", false);
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
            // if (methodExec == null)
            // {
            //     return choice;
            // }
            // if (methodName == "Callconstructor")
            // {
            //     string className = _options[choice-1].ToString();
            //     Util.CallConstructor(className);
            //     return choice;
            // }
            // else if (isString == true && methodName == "ProvidedInstance")// Uses methodname to check 
            // //methodexec is the instance bing used and the parameters are the methods to be used on the instance.
            // {
            //     Util.GenericVoidMethod(obje, extraMethods[choice]);
            // }
            // else if (isString == true)
            // {
            //     Util.GenericVoidMethod(_options[choice], Convert.ToString(extraMethods[choice]));
            // }
            // Util.GenericVoidMethod(_options[choice-1], methodExec);
            return choice;
        }

    }
