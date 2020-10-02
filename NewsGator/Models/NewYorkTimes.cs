using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public class NewYorkTimes : ITopHeadlines
  {
    public string Name { get; } = "New York Times";
    public string Target { get; } = "https://api.nytimes.com/svc/";

    public List<Article> GetTopHeadlines()
    {
      string endpoint = $"news/v3/content/all/all.json?api-key={EnvironmentalVariables.NewYorkTimesKey}";
      Task<string> apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      JArray jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "results");
      string[] vals = new string[4]{ "byline", "title", "abstract", "url" };
      List<Article> articleList = ApiHelper.GetTopList(jsonArticles, Name, vals);
      return articleList;
    }
  }
}