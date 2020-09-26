namespace NewsGator.Models
{
  public static class NewYorkTimes
  {
    public static string Name { get; } = "New York Times";
    public static string Target { get; } = "https://api.nytimes.com/svc/";

    public static Article[] GetTopHeadlines()
    {
      string endpoint = $"news/v3/content/all/all.json?api-key={EnvironmentalVariables.NewYorkTimesKey}";
      var apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      var jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, "results");
      Article[] articleList = new Article[100];
      int count = 0;
      string[] vals = new string[4]{ "byline", "title", "abstract", "url" };
      foreach(var jArticle in jsonArticles)
      {
        string[] valArr = ApiHelper.ValueGet(jArticle, vals);
        // articleList[count] = new Article(Name, vals[0], vals[1], vals[2], vals[3]);
        articleList[count] = new Article(Name, valArr);
        count++;
      }
      return articleList;
    }
  }
}