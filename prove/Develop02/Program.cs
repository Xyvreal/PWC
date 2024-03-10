using System;

class Program
{
/*
I exceeded requirements on this assignment by adding a check for previously created journals so that the user can easily return to the journal that they want without having to check the files.
This can be useful for individuals keeping multiple journals about different topics (although the prompts would still need to be changed).
These checks begin on line 38
*/
    static void Main(string[] args)
    {
        string JOURNALLIST = "AllJournals.csv";
        
        List<string> Journals = new List<string>();

        Journal Journal1 = new Journal();

        

        bool loop = true;
        while (loop)
        {
            int option;
            string choice = "waffle";
            while (!int.TryParse(choice, out option))
            {
                Console.Write("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\n>");
                choice = Console.ReadLine();
            }
            if(option == 1)
            {
                Journal1.NewEntry();
            }
            else if (option == 2)
            {
                Journal1.DisplayJournal();
            }
            else if (option == 3)
            {
                if (System.IO.File.Exists(JOURNALLIST))
                {
                    Console.Write("Please choose a journal to load from\n>");
                    using (StreamReader sr = new StreamReader(JOURNALLIST))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Journals.Add(line);
                        }
                    }
                    int optionnum = 1;
                    foreach (string book in Journals)
                    {
                        Console.WriteLine($"{optionnum}. {book}");
                        optionnum ++;
                    }
                    Console.Write("Please input the filename you would like to load from (inclucing .txt)\n>");
                    string filenames = Console.ReadLine();
                    Journal1.ReadJounal(filenames);
                }
                else
                {
                    Console.WriteLine("You currently do not have any Journals to load from.");
                }
            }
            else if (option == 4)
            {
                Console.Write("Please input the filename you would like to save to (inclucing .txt)\n>");
                string filenames = Console.ReadLine();
                Journal1.SaveJournal(filenames);
                if (System.IO.File.Exists(JOURNALLIST))
                {
                    using (StreamWriter sw = File.AppendText(JOURNALLIST))
                    {
                        sw.WriteLine($",{filenames}");
                    }
                }
                else
                {
                   using (StreamWriter sw = File.AppendText(JOURNALLIST))
                    {
                        sw.WriteLine($"{filenames}");
                    } 
                }
                }

            else if (option == 5)
            {
                Console.WriteLine("Goodby");
                loop = false;
            }
            else{
                Console.WriteLine("Please choose one of the listed options: \n");
            }
        }    
    }
}
