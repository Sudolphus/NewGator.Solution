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
  }
}