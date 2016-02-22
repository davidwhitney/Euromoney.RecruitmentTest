namespace ContentConsole
{
    public interface IContentParser
    {
        int CountNegativeWords(string _input);
        string FilterNegativeWordsIfEnabled(string input, bool shouldFilter);
    }
}