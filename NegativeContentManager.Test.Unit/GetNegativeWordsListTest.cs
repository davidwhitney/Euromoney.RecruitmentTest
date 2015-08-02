using NegativeContentManager.BO;
using NegativeContentManager.DAL.BO;
using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;
using NUnit.Framework;

namespace NegativeContentManager.Test.Unit
{
  [TestFixture]
  public class GetNegativeWordsListTest
  {
    private INegativeWordsManager<UserState, UserState> _getList;
    private UserState _userState;

    [SetUp]
    public void Setup()
    {
      _getList = new GetNegativeWordsList(new NegativeWordsDAL());
      _userState = new UserState
      {
        CurrentRequestType = UserState.RequestType.GetNegativeWords,
      };
    }

    [Test]
    public void ShouldGetNegativeWordsList()
    {
      var result = _getList.Manage(_userState);
      Assert.AreEqual(result.NegativeWordsList.Count, 4);
    }
  }
}
