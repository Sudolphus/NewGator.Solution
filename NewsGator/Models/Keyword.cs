using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NewsGator.Models
{
  public static class Keyword
  {
    public static string[] WordBreak(string phrase)
    {
      string parsedString = new string(phrase.Where(c => !char.IsPunctuation(c) && !char.IsSymbol(c)).ToArray()).ToLower();
      string[] words = parsedString.Split(' ');
      return words;
    }

    public static List<string> Keyphrase(string[] words)
    {
      List<string> phrases = new List<string>();
      string buildPhrase = "";
      foreach(string word in words)
      {
        if (File.ReadLines("C:\\Users\\pc\\Desktop\\NewGator\\NewsGator\\StopList.txt").Any(line => line.Contains(word)))
        {
          string addPhrase = buildPhrase.Trim();
          if (addPhrase != "")
          {
            phrases.Add(addPhrase);
          }
          buildPhrase = "";
        }
        else
        {
          buildPhrase += word;
        }
      }
      if (buildPhrase != "")
      {
        phrases.Add(buildPhrase.Trim());
      }
      return phrases;
    }
  }
}