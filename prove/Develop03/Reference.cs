using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference (string bookIn, int chapterIn, int verseIn)
    {
        _book = bookIn;
        _chapter = chapterIn;
        _verse = verseIn;
        _endVerse = 0;
    }

    public Reference (string bookIn, int chapterIn, int verseIn, int endVerseIn)
    {
        _book = bookIn;
        _chapter = chapterIn;
        _verse = verseIn;
        _endVerse = endVerseIn;
    }
    //Learned the following getters from a search. What benifits are there to using these over the simpler function creation 
    //like what I used in the word class?
    public int StartVerse
    {
        get { return _verse; }
        private set { _verse = value; }
    }
    
    public int EndingVerse
    {
        get {return _endVerse;}
        private set {_endVerse = value;}
    }

    public string GetDisplayText()
    {
        string assembled;

        if (_endVerse == 0)
        {
            assembled = $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            assembled = $"{_book} {_chapter}:{_verse} - {_endVerse}";
        }
        return assembled;
    }
}