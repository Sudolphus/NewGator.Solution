using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public static class NewsApiArticle
  {
    public static List<Article> GetTopHeadlines()
    {
      Task<string> apiCallTask = ApiHelper.ApiCall("https://newsapi.org/v2/", $"top-headlines?sources=bbc-news,associated-press,reuters,bloomberg&apiKey={EnvironmentalVariables.NewsApiKey}");
      string result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JArray jsonArticles = JsonConvert.DeserializeObject<JArray>(jsonResponse["articles"].ToString());

      List<Article> articleList = new List<Article>();
      foreach(JObject jArticle in jsonArticles)
      {
        string name = JsonConvert.DeserializeObject<JObject>(jArticle.GetValue("source").ToString()).GetValue("name").ToString();
        string author = jArticle.GetValue("author").ToString();
        string title = jArticle.GetValue("title").ToString();
        string description = jArticle.GetValue("description").ToString();
        string url = jArticle.GetValue("url").ToString();
        articleList.Add(new Article(name, author, title, description, url));
      }
      return articleList;
    }
  }
}