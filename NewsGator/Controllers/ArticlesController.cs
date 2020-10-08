using Microsoft.AspNetCore.Mvc;
using NewsGator.Models;
using System.Collections.Generic;

namespace NewsGator.Controllers
{
  public class ArticlesController : Controller
  {
    public IActionResult Index()
    {
      Source[] headlines = new Source[9]{ new NewsApi("BBC News"), new NewsApi("Associated Press"), new NewsApi("Reuters"), new NewsApi("Bloomberg"), new NewYorkTimes(), new NewsApi("CBS News"), new NewsApi("Wall Street Journal"), new NewsApi("Washington Post"), new NewsApi("Politico") };
      List<Article> articles = new List<Article>();
      foreach (Source source in headlines)
      {
        IEnumerable<Article> articleList = source.GetTopHeadlines();
        articles.AddRange(articleList);
      }
      foreach(Article article in articles)
      {
        HashSet<string> keywordsTitle = Keyword.Keyphrase(Keyword.WordBreak(article.Title));
        Keyword.Save(keywordsTitle);
        article.Save();
      }
      return View(articles);
    }

    public IActionResult List(string sourceName)
    {
      Source source;
      if (sourceName == "New York Times")
      {
        source = new NewYorkTimes();
      }
      else
      {
        source = new NewsApi(sourceName);
      }
      Article[] articles = source.GetTopHeadlines();
      return View(articles);
    }

    public IActionResult Reset()
    {
      Article.ClearAll();
      return RedirectToAction("Index", "Home");
    }
  }
}