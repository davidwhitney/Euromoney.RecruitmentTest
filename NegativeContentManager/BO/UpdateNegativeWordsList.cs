using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NegativeContentManager.DAL.Interfaces;
using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;

namespace NegativeContentManager.BO
{
  public class UpdateNegativeWordsList : NegativeWordsBase, INegativeWordsManager<UserState, UserState>
  {
    private readonly INegativeWordsDAL _negWordsDal;

    public UpdateNegativeWordsList(INegativeWordsDAL negWordsDal)
    {
      _negWordsDal = negWordsDal;
    }

    public UserState Manage(UserState userState)
    {
      if (userState.CurrentRequestType != UserState.RequestType.UpdateNegativeWords)
      {
        userState.Success = false;
        userState.ErrorMessage = "Illegal action!";
        return userState;
      }

      if (userState.NegativeWordsList == null)
      {
        userState.Success = false;
        userState.ErrorMessage = "Invalid request!";
        return userState;
      }

      userState.Success = _negWordsDal.SetNegativeWordsList(userState.NegativeWordsList);
      return userState;
    }
  }
}
