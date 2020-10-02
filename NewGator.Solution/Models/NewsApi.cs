// using System.Collections.Generic;

namespace NewsGator.Models
{
  public class NewsApi
  {
    public string Target { get; } = "https://newsapi.org/v2/";

    public Article[] GetTopHeadlines()
    {
      string endpoint = $"top-headlines?sources=bbc-news,associated-press,reuters,bloomberg&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      var apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      var jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "articles");
      string[] vals = new string[4]{ "author", "title", "description", "url" };
      Article[] articleList = ApiHelper.GetTopList(jsonArticles, name, vals);
      return articleList;
    }
  }
}