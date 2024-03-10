using System;

public class Journal
/*
Made up of a list of Entries
Function to read past entries from a file
Function to create a new entry
Function to save all entries to a file 
*/
{
    public List<Entry> Entries;
    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void NewEntry (string response = null, string date = null, string prompt = null)
    {
        if (response == null)
        {
            Entry newEntry = new Entry();
            Console.WriteLine(newEntry._prompt);
            response = newEntry.GetResponse();
            newEntry._response = response;
            Entries.Add(newEntry);
        }
        else if (date != null && prompt == null)
        {
            Entry newEntry = new Entry(response, date);
            Entries.Add(newEntry);
        }
        else if (date != null && prompt != null)
        {
            Entry newEntry = new Entry(response, date, prompt);
            Entries.Add(newEntry);
        }
        else{
            Entry newEntry = new Entry(response);
            Entries.Add(newEntry);        
        }
    }
    
    public void ReadJounal (string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("&");
            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];
            NewEntry(response, date, prompt);
        }
    }

    public void SaveJournal (string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(Entry i in Entries)
            {
                string date = i._date;
                string prompt = i._prompt;
                string response = i._response;
                outputFile.WriteLine($"{date}&{prompt}&{response}");
            }
        }
    }

    public void DisplayJournal ()
    {
        foreach(Entry i in Entries)
        {
            string date = i._date;
            string prompt = i._prompt;
            string response = i._response;
            Console.WriteLine($"Date: {date}  -- Prompt: {prompt}\n{response}\n");
        }
    }

}