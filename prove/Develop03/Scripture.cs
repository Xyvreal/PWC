using System;
using System.Runtime.CompilerServices;

public class Scripture 
{
    private Reference _reference;

    private List<List<Word>> _verses;

//Constructor
    private string[] Values {get;}
    public Scripture (Reference refIn, params string[] versesIn)
    /*
    Takes the scripture with seperated verses in order to improve readability
    */
    {
        Values = versesIn;
        _verses = new List<List<Word>>();
        foreach (string verse in versesIn)
        {
            List<Word> fullverse = new List<Word>();
            string[] words = verse.Split(' ');

            foreach (string word in words)
            {
                
                Word egg = new Word ($"{word}");
                fullverse.Add(egg);
            }

            _verses.Add(fullverse);

        }

        _reference = refIn;
    }

//Methods
    public void DisplayText ()
    //removed string return in favor of printing directly
    {
        
        List<string> verses = new List<string>();
        foreach (List<Word> verse in _verses)
        {
            //initializes new verse string
            string displayed = "";
            foreach (Word word in verse)
            {
                string shown = word.DisplayT();
                //adds a new word onto the verse string "displayed"
                displayed += $" {shown}";
            }
            //adds the full displayed string to the list of verses
            verses.Add(displayed);
        }

        //Adding verse number before each verse
        //Im sure there is a much more elegant way to do this but IDK how to do it yet
        int starter = _reference.StartVerse;
        int ender = _reference.EndingVerse;
        if (ender != 0)
        {
            int running = 0;
            int beginning = starter;
            while (ender >= beginning)
            {
                verses[running] = $"{beginning}. " + verses[running];
                running ++;
                beginning ++;
            }
        }
        else
        {
            verses[0] = $"{starter}. " + verses[0];
        }

        string finalString = "";
        foreach (string verse in verses)
        {
            finalString += $"{verse}\n\n";
        }
        string refTxt = _reference.GetDisplayText();
        string output = $"{refTxt}\n\n{finalString}";

        Console.Clear();

        Console.Write(output);

        //return output; 
    }

    public bool CompletelyHidden ()
    //Returns true if all words are hidden,  false otherwise
    {
        bool check = true;
        foreach (List<Word> verse in _verses)
        {
            foreach (Word word in verse)
            {
                if (word.IsHidden() == false)
                {
                    check = false;
                }
            }
        }

        return check;
    }

    public void HideRandom ()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(2,80);
        
        for (int i = 2; i < randomNumber; i ++)
        {
            int x = 0;
            int randomVerse;
            int randomWord;
            Word hiding = new Word("");

            while (x == 0)
            {
            randomVerse = rand.Next(_verses.Count);
            randomWord = rand.Next(_verses[randomVerse].Count);

            hiding = _verses[randomVerse][randomWord];

            if (CompletelyHidden() == true)
            {
                x++;
            }

            if (!hiding.IsHidden())
            {
                x++;
            }
            }

            hiding.Hide();
        }
    }
}