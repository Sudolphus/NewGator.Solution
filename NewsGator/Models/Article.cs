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

    public static List<Article> GetArticleList(MySqlDataReader rdr)
    {
      List<Article> articles = new List<Article>();
      while(rdr.Read())
      {
        int articlesId = rdr.GetInt32(0);
        string source = rdr.GetString(1);
        string author = rdr.GetString(2);
        string title = rdr.GetString(3);
        string summary = rdr.GetString(4);
        string url = rdr.GetString(5);
        string date = rdr.GetString(6);
        articles.Add(new Article(articlesId, source, author, title, summary, url, date));
      }
      return articles;
    }
    public static List<Article> GetAll()
    {
      MySqlConnection conn = DB.OpenConnection();
      MySqlCommand cmd = DB.CreateCommand(conn, @"SELECT * FROM articles;");
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Article> allArticles = Article.GetArticleList(rdr);
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
      DB.CloseConnection(conn);
    }

    public static Article Find(int id)
    {
      MySqlConnection conn = DB.OpenConnection();
      MySqlCommand cmd = DB.CreateCommand(conn, @"SELECT * FROM articles WHERE articlesId = @id;");
      cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      Article foundArticle = Article.GetArticleList(rdr)[0];
      DB.CloseConnection(conn);
      return foundArticle;
    }

    public static List<Article> Find(string[] filters)
    {
      string[] filterNames = new string[3] {"source", "author", "date" };
      MySqlConnection conn = DB.OpenConnection();
      string commandString = @"SELECT * FROM articles";
      bool multiFlag = false;
      for (int i = 0; i < 3; i++)
      {
        if (filters[i] != null)
        {
          if (!multiFlag)
          {
            commandString += $" WHERE {filterNames[i]} LIKE @{filterNames[i]}";
            multiFlag = true;
          }
          else
          {
            commandString += $" AND {filterNames[i]} LIKE @{filterNames[i]}";
          }
        }
      }
      if (filters[3] != null)
      {
        if (!multiFlag)
        {
          commandString += $" WHERE (title LIKE @title OR summary LIKE @summary)";
        }
        else
        {
          commandString += $" AND (title LIKE @title OR summary LIKE @summary)";
        }
      }
      commandString += ";";
      MySqlCommand cmd = DB.CreateCommand(conn, commandString);
      for (int i = 0; i < 3; i++)
      {
        if (filters[i] != null)
        {
          cmd.Parameters.Add($"@{filterNames[i]}", MySqlDbType.VarChar).Value = '%' + $"{filters[i]}" + '%';
        }
      }
      if (filters[3] != null)
      {
        cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = '%' + $"{filters[3]}" + '%';
        cmd.Parameters.Add("@summary", MySqlDbType.VarChar).Value = '%' + $"{filters[3]}" + '%';
      }
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Article> foundArticles = Article.GetArticleList(rdr);
      DB.CloseConnection(conn);
      return foundArticles;
    }

    public static List<Article> TopicFind(string topic)
    {
      MySqlConnection conn = DB.OpenConnection();
      string commandString = @"SELECT * FROM articles WHERE title LIKE @title OR summary LIKE @summary;";
      MySqlCommand cmd = DB.CreateCommand(conn, commandString);
      cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = '%' + topic + '%';
      cmd.Parameters.Add("@summary", MySqlDbType.LongText).Value = '%' + topic + '%';
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Article> foundArticles = Article.GetArticleList(rdr);
      DB.CloseConnection(conn);
      return foundArticles;
    }
  }
}