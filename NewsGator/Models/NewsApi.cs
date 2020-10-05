namespace NewsGator.Models
{
  public class NewsApi : Source
  {
    public string Code { get; }

    public NewsApi(string name) {
      this.Target = "https://newsapi.org/v2/";
      this.Name = name;
      this.Vals = new string[4] { "author", "title", "description", "url"};
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
        case "CBS News":
          this.Code = "cbs-news";
          break;
        case "Wall Street Journal":
          this.Code = "the-wall-street-journal";
          break;
        case "Washington Post":
          this.Code = "the-washington-post";
          break;
        case "Politico":
          this.Code = "politico";
          break;
      }
    }

    public string GetTopHeadlinesEndpoint()
    {
      return $"top-headlines?sources={Code}&pageSize=20&apiKey={EnvironmentalVariables.NewsApiKey}";
    }

    public override Article[] GetTopHeadlines()
    {
      string endpoint = this.GetTopHeadlinesEndpoint();
      Article[] articleList = this.ConvertToList(endpoint, "articles");
      return articleList;
    }
  }
}