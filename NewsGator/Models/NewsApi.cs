using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public class NewsApi : ITopHeadlines
  {
    public string Target { get; } = "https://newsapi.org/v2/";
    public string Name { get; }
    public string Code { get; }

    public NewsApi(string name) {
      this.Name = name;
      switch(name)
      {
        case "BBC News":
          this.Code = "bbc-news";
          break;
        case "Associated Press":
          this.Code = "associated-press";
          break;
        case "Reuters":
          this.Code = "reuters";
          break;
        case "Bloomberg":
          this.Code = "bloomberg";
          break;
      }
    }

    public string GetTopHeadlinesEndpoint()
    {
      return $"top-headlines?sources={Code}&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
    }

    public List<Article> GetTopHeadlines()
    {
      string endpoint = $"top-headlines?sources={Code}&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      Task<string> apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      JArray jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "articles");
      string[] vals = new string[4]{ "author", "title", "description", "url" };
      List<Article> articleList = ApiHelper.GetTopList(jsonArticles, Name, vals);
      return articleList;
    }
  }
}