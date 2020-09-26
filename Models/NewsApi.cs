// using System.Collections.Generic;

namespace NewsGator.Models
{
  public static class NewsApi
  {
    public static string Target { get; } = "https://newsapi.org/v2/";

    public static Article[] GetTopHeadlines()
    {
      string endpoint = $"top-headlines?sources=bbc-news,associated-press,reuters,bloomberg&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      var apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      var jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "articles");
      // List<Article> articleList = new List<Article>();
      Article[] articleList = new Article[100];
      int count = 0;
      string[] vals = new string[4]{ "author", "title", "description", "url" };
      foreach(var jArticle in jsonArticles)
      {
        string name = ApiHelper.ValueGet(jArticle, "source", "name");
        string[] valArr = ApiHelper.ValueGet(jArticle, vals);
        // articleList[count] = new Article(name, valArr[0], valArr[1], valArr[2], valArr[3]);
        articleList[count] = new Article(name, valArr);
        count++;
      }
      return articleList;
    }
  }
}