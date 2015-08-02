using System;
using NegativeContentManager.BO;
using NegativeContentManager.DAL.BO;
using NegativeContentManager.DTO;

namespace ContentConsole
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var contentManager = new ContentManager(new NegativeWordsDAL());
      var userState = new UserState
      {
        CurrentRequestType = UserState.RequestType.AnalyseContent,
        ContentInput = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting."
      };

      contentManager.Manage(userState);

      Console.WriteLine("Scanned the text:");
      Console.WriteLine(userState.ContentOutput);
      Console.WriteLine("Total Number of negative words: " + userState.TotalNegativeWordsInContent);

      Console.WriteLine("Press ANY key to exit.");
      Console.ReadKey();
    }
  }

}
