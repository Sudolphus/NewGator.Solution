namespace NewsGator.Models
{
  public class NewYorkTimes : Source
  {
    public NewYorkTimes()
    {
      this.Name = "New York Times";
      this.Target = "https://api.nytimes.com/svc/";
      this.AuthorName = "byline";
      this.TitleName = "title";
      this.SummaryName = "abstract";
      this.UrlName = "url";
    }
    public override Article[] GetTopHeadlines()
    {
      string endpoint = $"news/v3/content/all/all.json?api-key={EnvironmentalVariables.NewYorkTimesKey}";
      Article[] articleList = this.ConvertToList(endpoint, "results");
      return articleList;
    }
  }
}