namespace ContentConsole
{
    public class BadWordParseResponse
    {
        public string Content { get; set; }
        public int BadWordCount { get; set; }
        public string FilteredContent { get; set; }
    }
}