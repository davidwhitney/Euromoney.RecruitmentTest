namespace ContentConsole
{
    interface IBadWordParser
    {
        BadWordParseResponse Parse(string content);
    }
}
