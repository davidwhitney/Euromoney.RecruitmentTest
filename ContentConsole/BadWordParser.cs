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
            var filteredContent = content;
            foreach (var badWord in badWordRepository.GetAll())
            {
                badWords = badWords + ContentBadWordCount(badWord, content);
                filteredContent = FilterBadWords(badWord, filteredContent);
            }
            response.BadWordCount = badWords;
            response.FilteredContent = filteredContent;

            return response;
        }

        private string FilterBadWords(string badWord, string content)
        {
            if (badWord.Length <= 2)
            {
                return content;
            }
            var filteredBadWord = GenerateFilterWord(badWord);
            return content.Replace(badWord, filteredBadWord);
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

        private string GenerateFilterWord(string word)
        {
            return word.Substring(0, 1) + new string('#', word.Length - 2) + word.Substring(word.Length - 1, 1); ;
        }
    }
}
