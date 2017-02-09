using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.DataRepository;

namespace ContentConsole.Services
{
    /// <summary>
    /// Uses a repository to fetch banned words
    /// </summary>
    public class BannedWordRetrievalService : IBannedWordRetrievalService
    {
        private readonly IBannedWordRepository _bannedWordRepository;
        public BannedWordRetrievalService(IBannedWordRepository bannedWordRepository)
        {
            _bannedWordRepository = bannedWordRepository;
        }

        /// <summary>
        /// Get banned words
        /// </summary>
        /// <returns>An IEnumerable of banned words</returns>
        public IEnumerable<string> GetBannedWords()
        {
            return _bannedWordRepository.GetAll();
        }
    }
}

