using RestSharp;
using System.Threading.Tasks;

namespace NewsGator.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiCall()
    {
      RestClient client = new RestClient("https://newsapi.org/v2/");
      RestRequest request = new RestRequest($"top-headlines?sources=bbc-news,associated-press,reuters,bloomberg&apiKey={EnvironmentalVariables.NewsApiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}