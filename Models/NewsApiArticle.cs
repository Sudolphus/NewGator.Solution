using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public class NewsApiArticle
  {
    public JObject Source { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }

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
      // List<NewsApiArticle> newsApiList = JsonConvert.DeserializeObject<List<NewsApiArticle>>(jsonArticles.ToString());
      // foreach(NewsApiArticle article in newsApiList)
      // {
      //   string Name = JsonConvert.DeserializeObject<string>(article.Source.ToString());
      //   articleList.Add(new Article(Name, article.Author, article.Title, article.Description, article.Url));
      // }
      return articleList;
    }
  }
}