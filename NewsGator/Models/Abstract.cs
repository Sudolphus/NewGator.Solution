using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public abstract class Source
  {
    public string Name { get; set; }
    public string Target { get; set; }
    protected string[] Vals { get; set; }
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
      string[] returnArray = new string[4];
      for (int i = 0; i < 4; i++) {
        returnArray[i] = jsonObj.GetValue(this.Vals[i]).ToString();
      }
      return returnArray;
    }
  }
}