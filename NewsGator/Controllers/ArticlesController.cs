using Microsoft.AspNetCore.Mvc;
using NewsGator.Models;
using System.Collections.Generic;

namespace NewsGator.Controllers
{
  public class ArticlesController : Controller
  {
    public IActionResult Index()
    {
      ITopHeadlines[] headlines = new ITopHeadlines[9]{ new NewsApi("BBC News"), new NewsApi("Associated Press"), new NewsApi("Reuters"), new NewsApi("Bloomberg"), new NewYorkTimes(), new NewsApi("CBS News"), new NewsApi("Wall Street Journal"), new NewsApi("Washington Post"), new NewsApi("Politico") };
      List<Article> articles = new List<Article>();
      foreach (ITopHeadlines source in headlines)
      {
        IEnumerable<Article> articleList = source.GetTopHeadlines();
        articles.AddRange(articleList);
      }
      return View(articles);
    }

    public IActionResult List(string sourceName)
    {
      ITopHeadlines source;
      if (sourceName == "New York Times")
      {
        source = new NewYorkTimes();
      }
      else
      {
        source = new NewsApi(sourceName);
      }
      List<Article> articles = source.GetTopHeadlines();
      return View(articles);
    }
  }
}