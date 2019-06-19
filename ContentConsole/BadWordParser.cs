using System;

namespace ContentConsole
{
    public class BadWordParser : IBadWordParser
    {
        public BadWordParseResponse Parse(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content), $"Argument {nameof(content)} cannot be null");
            }

            var response = new BadWordParseResponse();
            response.Content = content;

            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            int badWords = 0;
            if (content.Contains(bannedWord1))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord2))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord3))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord4))
            {
                badWords = badWords + 1;
            }

            response.BadWordCount = badWords;

            return response;
        }
    }
}
