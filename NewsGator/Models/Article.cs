using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NewsGator.Models
{
  public class Article
  {
    public int ArticlesId { get; set; }
    public string Source { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Url { get; set; }
    public string Date { get; set; }

    public Article(int articlesId, string source, string author, string title, string summary, string url, string date)
    {
      this.ArticlesId = articlesId;
      this.Source = source;
      this.Author = author;
      this.Title = title;
      this.Summary = summary;
      this.Url = url;
      this.Date = date;
    }

    public Article(string source, string[] valArr)
    {
      this.Source = source;
      this.Author = valArr[0];
      this.Title = valArr[1];
      this.Summary = valArr[2];
      this.Url = valArr[3];
    }

    public override bool Equals(System.Object otherArticle)
    {
      if (!(otherArticle is Article))
      {
        return false;
      }
      else
      {
        Article newArticle = (Article) otherArticle;
        bool equalityFlag = true;
        if (this.Source != newArticle.Source)
        {
          equalityFlag = false;
        }
        else if (this.Author != newArticle.Author)
        {
          equalityFlag = false;
        }
        else if (this.Title != newArticle.Title)
        {
          equalityFlag = false;
        }
        else if (this.Summary != newArticle.Summary)
        {
          equalityFlag = false;
        }
        else if (this.Url != newArticle.Url)
        {
          equalityFlag = false;
        }
        return equalityFlag;
      }
    }

    public override int GetHashCode()
    {
      return ArticlesId;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.OpenConnection();
      MySqlCommand cmd = DB.CreateCommand(conn, @"DELETE FROM articles;");
      cmd.ExecuteNonQuery();
      DB.CloseConnection(conn);
    }
    public static List<Article> GetAll()
    {
      List<Article> allArticles = new List<Article>{ };
      MySqlConnection conn = DB.OpenConnection();
      MySqlCommand cmd = DB.CreateCommand(conn, @"SELECT * FROM articles;");
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int articlesId = rdr.GetInt32(0);
        string source = rdr.GetString(1);
        string author = rdr.GetString(2);
        string title = rdr.GetString(3);
        string summary = rdr.GetString(4);
        string url = rdr.GetString(5);
        string date = rdr.GetString(6);
        allArticles.Add(new Article(articlesId, source, author, title, summary, url, date));
      }
      DB.CloseConnection(conn);
      return allArticles;
    }

    public void Save()
    {
      MySqlConnection conn = DB.OpenConnection();
      MySqlCommand cmd = DB.CreateCommand(conn, @"INSERT INTO articles(source,author,title,summary,url,date) VALUES(@articleSource, @articleAuthor, @articleTitle, @articleSummary, @articleUrl, @articleDate);");
      cmd.Parameters.Add("@articleSource", MySqlDbType.VarChar).Value = this.Source;
      cmd.Parameters.Add("@articleAuthor", MySqlDbType.VarChar).Value = this.Author;
      cmd.Parameters.Add("@articleTitle", MySqlDbType.VarChar).Value = this.Title;
      cmd.Parameters.Add("@articleSummary", MySqlDbType.VarChar).Value = this.Summary;
      cmd.Parameters.Add("@articleUrl", MySqlDbType.VarChar).Value = this.Url;
      cmd.Parameters.Add("@articleDate", MySqlDbType.VarChar).Value = DateTime.Now.ToString("d");
      cmd.ExecuteNonQuery();
    }
  }
}