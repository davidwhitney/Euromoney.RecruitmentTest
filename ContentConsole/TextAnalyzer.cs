namespace ContentConsole
{
    public static class TextAnalyzer
    {
        private const string BannedWord1 = "swine";
        private const string BannedWord2 = "bad";
        private const string BannedWord3 = "nasty";
        private const string BannedWord4 = "horrible";

        public static int CountBadWords(string text)
        {

            int badWords = 0;
            if (text.Contains(BannedWord1))
            {
                badWords = badWords + 1;
            }
            if (text.Contains(BannedWord2))
            {
                badWords = badWords + 1;
            }
            if (text.Contains(BannedWord3))
            {
                badWords = badWords + 1;
            }
            if (text.Contains(BannedWord4))
            {
                badWords = badWords + 1;
            }

            return badWords;
        }
    }
}
