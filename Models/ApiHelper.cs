using RestSharp;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiCall(string source, string endpoint)
    {
      RestClient client = new RestClient(source);
      RestRequest request = new RestRequest(endpoint, Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}