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
      Assert.AreEqual(bbc.Name, "BBC News");
      Assert.AreEqual(bbc.Code, "bbc-news");
    }
  }
}