using System;
namespace ContentConsole
{
    public interface INegativeWordsFilteration
    {
        /// <summary>
        /// Get count of negative words from the content
        /// </summary>
        int NegativeWordCount(string content);

        /// <summary>
        /// Add negative words in the data store
        /// </summary>
        void AddNegativeWords(string word);

        /// <summary>
        /// Remove negative words in the data store
        /// </summary>
        void RemoveNegativeWords(string word);

        /// <summary>
        /// Filter negative words from the content based on isEnable flag
        /// </summary>
        string FilterNegativeWords(string content, bool isEnable);
    }
}
