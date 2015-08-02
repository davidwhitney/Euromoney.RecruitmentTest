using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NegativeContentManager.BO
{
  public abstract class NegativeWordsBase 
  {
    public string MaskNegativeWords(string content, List<string> negativeWordsList)
    {
      foreach (var negWord in negativeWordsList.Where(n => n.Length > 2))
      {
        // TODO: gets the first and last letter from Negative Word. It can mess up the casing of the word in content.
        var negWordLength = negWord.Length;
        content = Regex.Replace(content, negWord,
          negWord.Substring(0,1) + "".PadLeft(negWordLength - 2, '#') + negWord.Substring(negWordLength - 1), RegexOptions.IgnoreCase);
      }

      return content;
    }

    public int CountNegativeWordsInContent(string content, List<string> negativeWordsList )
    {
      return negativeWordsList.Count(negWord => content.IndexOf(negWord, StringComparison.OrdinalIgnoreCase) >= 0);
    }
  }
}
