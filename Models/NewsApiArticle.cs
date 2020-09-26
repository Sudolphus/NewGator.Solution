using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public static class NewsApiArticle
  {
    public static string Target { get; } = "https://newsapi.org/v2/";

    public static List<Article> GetTopHeadlines()
    {
      string endpoint = $"top-headlines?sources=bbc-news,associated-press,reuters,bloomberg&apiKey={EnvironmentalVariables.NewsApiKey}";
      Task<string> apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      var jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "articles");
      
      List<Article> articleList = new List<Article>();
      foreach(var jArticle in jsonArticles)
      {
        string name = ApiHelper.ValueGet(jArticle, "source", "name");
        string[] vals = { "author", "title", "description", "url" };
        string[] valArr = ApiHelper.ValueGet(jArticle, vals);
        articleList.Add(new Article(name, valArr[0], valArr[1], valArr[2], valArr[3]));
      }
      return articleList;
    }
  }
}