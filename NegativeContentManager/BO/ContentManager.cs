using NegativeContentManager.DAL.Interfaces;
using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;

namespace NegativeContentManager.BO
{
  public class ContentManager : IContentManager
  {
    private readonly INegativeWordsManager<UserState, UserState> _analyse;
    private readonly INegativeWordsManager<UserState, UserState> _read;
    private readonly INegativeWordsManager<UserState, UserState> _getNegWordsList;
    private readonly INegativeWordsManager<UserState, UserState> _updateNegWordsList;

    // TODO: Use external dependency injection like Ninject
    public ContentManager(INegativeWordsDAL negWordsDal) : this (new AnalyseContentForNegativeWords(), 
      new ReadContentWithNegativeWords(), new GetNegativeWordsList(negWordsDal), new UpdateNegativeWordsList(negWordsDal))
    {
    }

    public ContentManager(INegativeWordsManager<UserState, UserState> analyse, 
      INegativeWordsManager<UserState, UserState> read,
      INegativeWordsManager<UserState, UserState> getNegWordsList,
      INegativeWordsManager<UserState, UserState> updateNegWordsList)
    {
      _analyse = analyse;
      _read = read;
      _getNegWordsList = getNegWordsList;
      _updateNegWordsList = updateNegWordsList;
    }

    public UserState Manage(UserState value)
    {
      value = _getNegWordsList.Manage(value);

      switch (value.CurrentRequestType)
      {
        case UserState.RequestType.AnalyseContent:
          value = _analyse.Manage(value);
          break;
        case UserState.RequestType.ReadContent:
          value = _read.Manage(value);
          break;
        case UserState.RequestType.UpdateNegativeWords:
          value = _updateNegWordsList.Manage(value);
          break;
      }

      // Remove NegativeWordsList if not requested for Admin
      if (value.CurrentRequestType != UserState.RequestType.GetNegativeWords)
        value.NegativeWordsList = null;

      return value;
    }
  }
}
