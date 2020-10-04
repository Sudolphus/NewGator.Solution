using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public abstract class Source
  {
    public string Name { get; set; }
    public string Target { get; set; }
    protected string AuthorName { get; set; }
    protected string TitleName { get; set; }
    protected string SummaryName { get; set; }
    protected string UrlName { get; set; }

    public abstract Article[] GetTopHeadlines();
    
    protected Article[] ConvertToList(string endpoint, string arrayName)
    {
      Task<string> apiCallTask = ApiHelper.ApiCall(Target, endpoint);
      JArray jsonArticles = ApiHelper.Deserialize(apiCallTask.Result, arrayName);
      Article[] articleList = this.GetTopList(jsonArticles);
      return articleList;
    }

    private Article[] GetTopList(JArray jsonArticles)
    {
      List<Article> articles = new List<Article>();
      foreach(JObject jArticle in jsonArticles)
      {
        string[] valArr = this.ValueGet(jArticle);
        articles.Add(new Article(Name, valArr));
      }
      return articles.ToArray();
    }

    private string[] ValueGet(JObject jsonObj)
    {
      string[] values = new string[4]{ AuthorName, TitleName, SummaryName, UrlName };
      string[] returnArray = new string[values.Length];
      for (int i = 0; i < values.Length; i++) {
        returnArray[i] = jsonObj.GetValue(values[i]).ToString();
      }
      return returnArray;
    }
  }
}