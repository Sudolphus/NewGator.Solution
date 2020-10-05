namespace NewsGator.Models
{
  public class NewYorkTimes : Source
  {
    public NewYorkTimes()
    {
      this.Name = "New York Times";
      this.Target = "https://api.nytimes.com/svc/";
      this.Vals = new string[4] {"byline", "title", "abstract", "url"};
    }
    public override Article[] GetTopHeadlines()
    {
      string endpoint = $"news/v3/content/all/all.json?api-key={EnvironmentalVariables.NewYorkTimesKey}";
      Article[] articleList = this.ConvertToList(endpoint, "results");
      return articleList;
    }
  }
}