using System.Collections.Generic;
using NegativeContentManager.BO;
using NegativeContentManager.DTO;
using NegativeContentManager.Interfaces;
using NUnit.Framework;

namespace NegativeContentManager.Test.Unit
{
  [TestFixture]
  public class AnalyseContentForNegativeWordsTest
  {
    private INegativeWordsManager<UserState, UserState> _analyse;
    private UserState _userState;

    [SetUp]
    public void Setup()
    {
      _analyse = new AnalyseContentForNegativeWords();
      _userState = new UserState
      {
        CurrentRequestType = UserState.RequestType.AnalyseContent,
        NegativeWordsList = new List<string> { "swine", "bad", "nasty", "horrible"}
      };
    }

    [Test]
    public void ShouldGetNegativeWordsCountOfTwo()
    {
      _userState.ContentInput =
        "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
      var result = _analyse.Manage(_userState);

      Assert.AreEqual(2, result.TotalNegativeWordsInContent);
    }

    [Test]
    public void ShouldReturnPlainContentAsPassed()
    {
      var contentInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
      _userState.ContentInput = contentInput;
      var result = _analyse.Manage(_userState);

      Assert.AreEqual(contentInput, result.ContentOutput);
    }

  }
}
