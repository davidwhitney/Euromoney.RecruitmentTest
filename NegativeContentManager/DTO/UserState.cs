using System.Collections.Generic;

namespace NegativeContentManager.DTO
{
  public class UserState
  {
    public enum RequestType
    {
      AnalyseContent, ReadContent, GetNegativeWords, UpdateNegativeWords
    };

    public RequestType CurrentRequestType { get; set; }
    public string ContentInput { get; set; }
    public string ContentOutput { get; set; }
    public int TotalNegativeWordsInContent { get; set; }
    public List<string> NegativeWordsList { get; set; }
    public int NegativeWordsListCount { get; set; }

    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
  }
}
