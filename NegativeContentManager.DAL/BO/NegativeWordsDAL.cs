using System.Collections.Generic;
using NegativeContentManager.DAL.Interfaces;

namespace NegativeContentManager.DAL.BO
{
  public class NegativeWordsDAL : INegativeWordsDAL
  {
    private static List<string> _negativeWordsList = new List<string>
    {
      "swine",
      "bad",
      "nasty",
      "horrible"
    };

    public List<string> GetNegativeWordsList()
    {
      return _negativeWordsList;
    }

    public bool SetNegativeWordsList(List<string> negWordsList)
    {
      _negativeWordsList = negWordsList;
      return true;
    }
  }
}
