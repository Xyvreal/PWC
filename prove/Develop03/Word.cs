using System;
public class Word

{
    private bool _vis;
    private string _word;

    private string _displayText;
    
    public Word(string text)
    {
        _vis = true;
        _word = text;
        _displayText = _word;
    }

    public void Hide ()
    {
        _vis = false;
        string start = _word;
        int length = start.Length;
        string hidden = new string ('_', length);
        _displayText = hidden;
    }

    public string DisplayT()
    {
        return _displayText;
    }
    
    public bool IsHidden()
    {
        return !_vis;
    }
}