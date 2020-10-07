namespace NewsGator.Models
{
  public class Filter
  {
    public string Source { get; set; }
    public string Author { get; set; }
    public string Topic { get; set; }
    public string Date { get; set; }

    public Filter()
    {
      this.Source = null;
      this.Author = null;
      this.Topic = null;
      this.Date = null;
    }

    public Filter(string source = null, string author = null, string topic = null, string date = null)
    {
      this.Source = source;
      this.Author = author;
      this.Topic = topic;
      this.Date = date;
    }
  }
}