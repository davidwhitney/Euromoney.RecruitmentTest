namespace ContentConsole
{
    using System.Text.RegularExpressions;

    public static class TextAnalyzer
    {
        private const string BannedWord1 = "swine";
        private const string BannedWord2 = "bad";
        private const string BannedWord3 = "nasty";
        private const string BannedWord4 = "horrible";

        public static int CountBadWords(string text)
        {
            int badWords = 0;

            MatchCollection matches = Regex.Matches(text, BannedWord1);

            badWords += matches.Count;

            matches = Regex.Matches(text, BannedWord2);

            badWords += matches.Count;

            matches = Regex.Matches(text, BannedWord3);

            badWords += matches.Count;

            matches = Regex.Matches(text, BannedWord4);

            badWords += matches.Count;

            return badWords;
        }
    }
}
