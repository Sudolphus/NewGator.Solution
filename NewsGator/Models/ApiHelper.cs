using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public static class ApiHelper
  {
    public static async Task<string> ApiCall(string source, string endpoint)
    {
      RestClient client = new RestClient(source);
      RestRequest request = new RestRequest(endpoint, Method.GET);
      IRestResponse response = await client.ExecuteAsync(request);
      return response.Content;
    }

    public static JArray Deserialize(string jsonString, string arrayName)
    {
      JObject jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString);
      JArray jsonArray = JsonConvert.DeserializeObject<JArray>(jsonObject.GetValue($"{arrayName}").ToString());
      return jsonArray;
    }

    public static string[] ValueGet(JObject jsonObj, string[] values)
    {
      string[] returnArray = new string[values.Length];
      for (int i = 0; i < values.Length; i++) {
        returnArray[i] = jsonObj.GetValue(values[i]).ToString();
      }
      return returnArray;
    }

    public static string ValueGet(JObject jsonObj, string childName, string valueName)
    {
      return JsonConvert.DeserializeObject<JObject>(jsonObj.GetValue(childName).ToString()).GetValue(valueName).ToString();
    }

    public static List<Article> GetTopList(JArray jsonArticles, string name, string[] vals)
    {
      List<Article> articles = new List<Article>();
      foreach(JObject jArticle in jsonArticles)
      {
        string[] valArr = ApiHelper.ValueGet(jArticle, vals);
        articles.Add(new Article(name, valArr));
      }
      return articles;
    }
  }
}