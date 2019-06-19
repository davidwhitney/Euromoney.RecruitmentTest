using System;

namespace ContentConsole
{
    public class BadWordParser : IBadWordParser
    {
        private readonly IBadWordRepository badWordRepository;

        public BadWordParser(IBadWordRepository badWordRepository)
        {
            this.badWordRepository = badWordRepository;
        }

        public BadWordParseResponse Parse(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content), $"Argument {nameof(content)} cannot be null");
            }

            var response = new BadWordParseResponse();
            response.Content = content;

            var badWords = 0;
            foreach (var badWord in badWordRepository.GetAll())
            {
                badWords = badWords + ContentBadWordCount(badWord, content);
            }
            response.BadWordCount = badWords;


            return response;
        }

        private int ContentBadWordCount(string badWord, string content)
        {
            var badWordIndex = content.ToLowerInvariant().IndexOf(badWord.ToLowerInvariant());
            if (badWordIndex > -1)
            {
                return 1 + ContentBadWordCount(badWord, content.Substring(badWordIndex + badWord.Length));
            }
            else
            {
                return 0;
            }
        }
    }
}
