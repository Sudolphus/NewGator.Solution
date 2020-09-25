namespace NewsGator.Models
{
  public class Article
  {
    public string Source { get; }
    public string Author { get; }
    public string Title { get; }
    public string Summary { get; }
    public string Url { get; }

    public Article(string source, string author, string title, string summary, string url)
    {
      this.Source = source;
      this.Author = author;
      this.Title = title;
      this.Summary = summary;
      this.Url = url;
    }
  }
}