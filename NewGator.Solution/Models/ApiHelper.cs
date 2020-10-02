using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  public static class ApiHelper
  {
    public static async Task<string> ApiCall(string source, string endpoint)
    {
      RestClient client = new RestClient(source);
      RestRequest request = new RestRequest(endpoint, Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static JArray Deserialize(string jsonString, string arrayName)
    {
      JObject jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString);
      JArray jsonArray = JsonConvert.DeserializeObject<JArray>(jsonObject.GetValue($"{arrayName}").ToString());
      return jsonArray;
    }

    public static string[] ValueGet(JToken jsonToken, string[] values)
    {
      JObject jsonObj = jsonToken as JObject;
      string[] returnArray = new string[values.Length];
      for (int i = 0; i < values.Length; i++) {
        returnArray[i] = jsonObj.GetValue(values[i]).ToString();
      }
      return returnArray;
    }

    public static string ValueGet(JToken jsonToken, string childName, string valueName)
    {
      JObject jsonObj = jsonToken as JObject;
      return JsonConvert.DeserializeObject<JObject>(jsonObj.GetValue(childName).ToString()).GetValue(valueName).ToString();
    }

    public static Article[] GetTopList(JArray jsonArticles, string name, string[] vals)
    {
      int count = 0;
      Article[] articleList = new Article[100];
      foreach(var jArticle in jsonArticles)
      {
        string[] valArr = ApiHelper.ValueGet(jArticle, vals);
        articleList[count] = new Article(name, valArr);
        count++;
      } 
      return articleList;
    }
  }
}