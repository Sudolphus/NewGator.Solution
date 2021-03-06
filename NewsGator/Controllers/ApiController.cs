using Microsoft.AspNetCore.Mvc;
using NewsGator.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsGator.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InfoController : ControllerBase
  {
    [HttpGet]
    public List<Article> Get([FromQuery] Filter filter)
    {
      string[] filters = new string[4]{ filter.Source, filter.Author, filter.Date, filter.Topic };
      List<Article> articleList = Article.Find(filters);
      articleList.Sort();
      articleList.Reverse();
      return articleList;
    }
  }
}