namespace NewsGator.Models
{
  public class NewYorkTimes : ITopHeadlines
  {
    public string Name { get; } = "New York Times";
    public string Target { get; } = "https://api.nytimes.com/svc/";

    public Article[] GetTopHeadlines()
    {
      string endpoint = $"news/v3/content/all/all.json?api-key={EnvironmentalVariables.NewYorkTimesKey}";
      var apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      var jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "results");
      string[] vals = new string[4]{ "byline", "title", "abstract", "url" };
      Article[] articleList = ApiHelper.GetTopList(jsonArticles, Name, vals);
      return articleList;
    }
  }
}