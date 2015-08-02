using NegativeContentManager.DAL.Interfaces;
using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;

namespace NegativeContentManager.BO
{
  public class GetNegativeWordsList : INegativeWordsManager<UserState, UserState>
  {
    private readonly INegativeWordsDAL _negWordsDal;

    public GetNegativeWordsList(INegativeWordsDAL negWordsDal)
    {
      _negWordsDal = negWordsDal;
    }

    public UserState Manage(UserState userState)
    {
      userState.NegativeWordsList = _negWordsDal.GetNegativeWordsList();
      userState.NegativeWordsListCount = userState.NegativeWordsList.Count;
      userState.Success = true;

      return userState;
    }
  }
}
