using Microsoft.AspNetCore.Mvc;
using NewsGator.Models;
using System.Collections.Generic;

namespace NewsGator.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InfoController : ControllerBase
  {
    [HttpGet]
    public List<Article> Get([FromQuery] Filter filter)
    {
      string[] filters = new string[6]{ filter.Source, filter.Author, filter.Title, filter.Summary, filter.Url, filter.Date };
      List<Article> articleList = Article.Find(filters);
      return articleList;
    }
  }
}