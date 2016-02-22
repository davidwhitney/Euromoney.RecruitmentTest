namespace ContentConsole
{
    public interface IContentParser
    {
        int CountNegativeWords(string input);
        string FilterNegativeWords(string input);
    }
}