using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public class NewsApiArticle
  {
    // public string Source { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string url { get; set; }

    public static List<NewsApiArticle> GetTopHeadlines()
    {
      Task<string> apiCallTask = ApiHelper.ApiCall("https://newsapi.org/v2/", $"top-headlines?sources=bbc-news,associated-press,reuters,bloomberg&apiKey={EnvironmentalVariables.NewsApiKey}");
      string result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JArray jsonArticles = JsonConvert.DeserializeObject<JArray>(jsonResponse["articles"].ToString());
      List<NewsApiArticle> articleList = JsonConvert.DeserializeObject<List<NewsApiArticle>>(jsonArticles.ToString());
      return articleList;
    }
  }
}