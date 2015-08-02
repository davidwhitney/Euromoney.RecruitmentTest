using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;

namespace NegativeContentManager.BO
{
  public class AnalyseContentForNegativeWords : NegativeWordsBase, INegativeWordsManager<UserState, UserState>
  {
    public UserState Manage(UserState userState)
    {
      if (userState.CurrentRequestType != UserState.RequestType.AnalyseContent)
      {
        userState.Success = false;
        userState.ErrorMessage = "Illegal action!";
        return userState;
      }

      if (string.IsNullOrEmpty(userState.ContentInput) || userState.NegativeWordsList == null || userState.NegativeWordsList.Count < 1)
      {
        userState.Success = false;
        userState.ErrorMessage = "Invalid request!";
        return userState;
      }

      userState.TotalNegativeWordsInContent = CountNegativeWordsInContent(userState.ContentInput, userState.NegativeWordsList);
      userState.ContentOutput = userState.ContentInput;
      userState.Success = true;

      return userState;
    }
  }
}
