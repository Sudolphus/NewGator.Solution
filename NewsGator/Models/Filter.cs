namespace NewsGator.Models
{
  public class Filter
  {
    public string Source { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Url { get; set; }
    public string Date { get; set; }

    public Filter()
    {
      this.Source = null;
      this.Author = null;
      this.Title = null;
      this.Summary = null;
      this.Url = null;
      this.Date = null;
    }

    public Filter(string source = null, string author = null, string title = null, string summary = null, string url = null, string date = null)
    {
      this.Source = source;
      this.Author = author;
      this.Title = title;
      this.Summary = summary;
      this.Url = url;
      this.Date = date;
    }
  }
}