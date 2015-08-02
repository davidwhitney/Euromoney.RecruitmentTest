using System.Collections.Generic;

namespace NegativeContentManager.DAL.Interfaces
{
  public interface INegativeWordsDAL
  {
    List<string> GetNegativeWordsList();
    bool SetNegativeWordsList(List<string> negWordsList);
  }
}
