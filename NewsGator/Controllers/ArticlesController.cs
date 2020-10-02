using Microsoft.AspNetCore.Mvc;
using NewsGator.Models;
using System.Collections.Generic;

namespace NewsGator.Controllers
{
  public class ArticlesController : Controller
  {
    public IActionResult Index()
    {
      ITopHeadlines[] headlines = new ITopHeadlines[5]{ new NewsApi("BBC News"), new NewsApi("Associated Press"), new NewsApi("Reuters"), new NewsApi("Bloomberg"), new NewYorkTimes() };
      List<Article> articles = new List<Article>();
      foreach (ITopHeadlines source in headlines)
      {
        Article[] articleList = source.GetTopHeadlines();
        articles.AddRange(articleList);
      }
      return View(articles);
    }
  }
}