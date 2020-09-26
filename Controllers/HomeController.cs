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
      Article[] articleList = NewsApi.GetTopHeadlines();
      return View(articleList);
    }
  }
}