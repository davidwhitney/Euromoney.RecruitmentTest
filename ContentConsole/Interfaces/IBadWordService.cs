namespace ContentConsole
{
    interface IBadWordService
    {
        int GetBadWordCount(string content);
        string GetFilteredContent(string content);
    }
}
