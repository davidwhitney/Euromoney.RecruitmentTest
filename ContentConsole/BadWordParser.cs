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

            foreach (var badWord in badWordRepository.GetAll())
            {
                if (content.ToLowerInvariant().Contains(badWord.ToLowerInvariant()))
                {
                    response.BadWordCount++;
                }
            }

            return response;
        }
    }
}
