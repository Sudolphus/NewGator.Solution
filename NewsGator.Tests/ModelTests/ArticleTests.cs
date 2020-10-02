using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsGator.Models;

namespace NewsGator.Tests
{
  [TestClass]
  public class ArticleTests
  {
    [TestMethod]
    public void Article_ShouldInstantiateAnObject_Article()
    {
      Article newArticle = new Article("source", "author", "title", "summary", "url");
      Assert.AreEqual(typeof(Article), newArticle.GetType());
      Assert.AreEqual("source", newArticle.Source);
      Assert.AreEqual("author", newArticle.Author);
      Assert.AreEqual("title", newArticle.Title);
      Assert.AreEqual("summary", newArticle.Summary);
      Assert.AreEqual("url", newArticle.Url);
    }

    [TestMethod]
    public void Article_ShouldCreateArticleWithAlternateConstructor_Article()
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      Article newArticle = new Article("source", valArr);
      Assert.AreEqual(typeof(Article), newArticle.GetType());
      Assert.AreEqual("source", newArticle.Source);
      Assert.AreEqual("author", newArticle.Author);
      Assert.AreEqual("title", newArticle.Title);
      Assert.AreEqual("summary", newArticle.Summary);
      Assert.AreEqual("url", newArticle.Url);
    }

    [TestMethod]
    public void NewsApi_ShouldInstantiateACallToBBCNews_BBCNewsObject()
    {
      NewsApi bbc = new NewsApi("BBC News");
      Assert.AreEqual(typeof(NewsApi), bbc.GetType());
      Assert.AreEqual(bbc.Target, "https://newsapi.org/v2/");
      Assert.AreEqual(bbc.Name, "BBC News");
      Assert.AreEqual(bbc.Code, "bbc-news");
    }

    [TestMethod]
    public void NewsApi_ShouldCreateTheCorrectEndpoint_BBCEndpoint()
    {
      NewsApi bbc = new NewsApi("BBC News");
      string endpoint = $"top-headlines?sources=bbc-news&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      Assert.AreEqual(endpoint, bbc.GetTopHeadlinesEndpoint());
    }

    [TestMethod]
    public void NewsApi_ShouldInstantiateACallToAssociatedPress_APNewsObject()
    {
      NewsApi ap = new NewsApi("Associated Press");
      Assert.AreEqual(typeof(NewsApi), ap.GetType());
      Assert.AreEqual(ap.Target, "https://newsapi.org/v2/");
      Assert.AreEqual(ap.Name, "Associated Press");
      Assert.AreEqual(ap.Code, "associated-press");
    }

    [TestMethod]
    public void NewsApi_ShouldCreateTheCorrectEndpoint_APEndpoint()
    {
      NewsApi ap = new NewsApi("Associated Press");
      string endpoint = $"top-headlines?sources=associated-press&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      Assert.AreEqual(endpoint, ap.GetTopHeadlinesEndpoint());
    }

    [TestMethod]
    public void NewsApi_ShouldInstantiateACallToAssociatedPress_ReutersNewsObject()
    {
      NewsApi r = new NewsApi("Reuters");
      Assert.AreEqual(typeof(NewsApi), r.GetType());
      Assert.AreEqual(r.Target, "https://newsapi.org/v2/");
      Assert.AreEqual(r.Name, "Reuters");
      Assert.AreEqual(r.Code, "reuters");
    }

    [TestMethod]
    public void NewsApi_ShouldCreateTheCorrectEndpoint_REndpoint()
    {
      NewsApi r = new NewsApi("Reuters");
      string endpoint = $"top-headlines?sources=reuters&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      Assert.AreEqual(endpoint, r.GetTopHeadlinesEndpoint());
    }

    [TestMethod]
    public void NewsApi_ShouldInstantiateACallToAssociatedPress_BloombergNewsObject()
    {
      NewsApi b = new NewsApi("Bloomberg");
      Assert.AreEqual(typeof(NewsApi), b.GetType());
      Assert.AreEqual(b.Target, "https://newsapi.org/v2/");
      Assert.AreEqual(b.Name, "Bloomberg");
      Assert.AreEqual(b.Code, "bloomberg");
    }

    [TestMethod]
    public void NewsApi_ShouldCreateTheCorrectEndpoint_BEndpoint()
    {
      NewsApi b = new NewsApi("Bloomberg");
      string endpoint = $"top-headlines?sources=bloomberg&pageSize=100&apiKey={EnvironmentalVariables.NewsApiKey}";
      Assert.AreEqual(endpoint, b.GetTopHeadlinesEndpoint());
    }
  }
}