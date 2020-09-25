using Microsoft.AspNetCore.Mvc;
using NewsGator.Models;
using System.Collections.Generic;

namespace NewsGator.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult TopHeadlines()
    {
      List<Article> articleList = NewsApiArticle.GetTopHeadlines();
      return View(articleList);
    }
  }
}