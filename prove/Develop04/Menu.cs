using System;

//takes an array of names of classes that contain a 'Run' function and prints them nicely while providing and reading 
//the users choice and then executing the run function of that class. 
class Menu
    {
        private List<Activity> _options;

        public Menu ()
        {
            _options = new List<Activity>()
            {
                new Breathing(),
                new Listing(),
                new Reflecting()
            };
        }

        public void DisplayMenu()
        {
            Utility.IncramentalString("Please choose one of the following options:\n\n");
            int number = 1;
            foreach (Activity opt in _options)
            {
                string option = opt.Name;
                Utility.IncramentalString($"{number}. {option}\n", false);
                number ++;
            }
            Utility.IncramentalString($"{number}. Quit \n=> ", false);
            int choice;
            while (true)
            {
                choice = Utility.IntegerInput();
                if (choice <= number)
                {
                    if (choice == number)
                    {
                        Utility.IncramentalString("Goodbye!");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                    }
                    if (choice < 0)
                    {
                        Utility.IncramentalString("\nPlease input one of the choices above.=> ", false);
                    }
                    break;
                }

                else
                {
                    Utility.IncramentalString("\nPlease input one of the choices above. => ", false);
                }
            }
            _options[choice-1].Run();

            
        }

    }