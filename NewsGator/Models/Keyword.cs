using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NewsGator.Models
{
  public static class Keyword
  {

    public static void Save(HashSet<string> phraseList)
    {
      MySqlConnection conn = DB.OpenConnection();
      foreach(string phrase in phraseList)
      {
        MySqlCommand cmd = DB.CreateCommand(conn, @"INSERT INTO keyphrases(keyphrase) VALUES(@keyphrase) ON DUPLICATE KEY UPDATE count = count + 1;");
        cmd.Parameters.Add("@keyphrase", MySqlDbType.VarChar).Value = phrase;
        cmd.ExecuteNonQuery();
      }
      DB.CloseConnection(conn);
    }

    public static string[] WordBreak(string phrase)
    {
      string parsedString = new string(phrase.Where(c => !char.IsPunctuation(c) && !char.IsSymbol(c)).ToArray()).ToLower();
      string[] words = parsedString.Split(' ');
      return words;
    }

    public static HashSet<string> Keyphrase(string[] words)
    {
      HashSet<string> phrases = new HashSet<string>();
      string buildPhrase = "";
      foreach(string word in words)
      {
        Regex reg = new Regex($"^{word}$");
        if (File.ReadLines("C:\\Users\\pc\\Desktop\\NewGator\\NewsGator\\StopList.txt").Any(line => reg.IsMatch(line)))
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
          phrases.Add(word);
          buildPhrase += $" {word}";
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