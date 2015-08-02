using System.Collections.Generic;
using NegativeContentManager.BO;
using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;
using NUnit.Framework;

namespace NegativeContentManager.Test.Unit
{
  [TestFixture]
  public class ReadContentWithNegativeWordsTest
  {
    private INegativeWordsManager<UserState, UserState> _read;
    private UserState _userState;

    [SetUp]
    public void Setup()
    {
      _read = new ReadContentWithNegativeWords();
      _userState = new UserState
      {
        CurrentRequestType = UserState.RequestType.ReadContent,
        NegativeWordsList = new List<string> { "swine", "bad", "nasty", "horrible" }
      };
    }

    [Test]
    public void ShouldMaskNegativeWords()
    {
      _userState.ContentInput =
        "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
      var result = _read.Manage(_userState);

      Assert.AreEqual("The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.", result.ContentOutput);
    }
  }
}
