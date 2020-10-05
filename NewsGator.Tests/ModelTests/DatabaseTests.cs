using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsGator.Models;
using System;
using System.Collections.Generic;

namespace NewsGator.Tests
{
  [TestClass]
  public class DatabaseTests : IDisposable
  {
    public void Dispose()
    {
      Article.ClearAll();
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ArticlesList()
    {
      List<Article> newList = new List<Article>{};
      List<Article> results = Article.GetAll();
      CollectionAssert.AreEqual(newList, results);
    }

    [TestMethod]
    public void Equals_RecordsWithEqualValuesAreEqual_True()
    {
      Article newArticle = new Article(1, "source", "author", "title", "summary", "url", "10-5-2020");
      Article newArticle2 = new Article(1, "source", "author", "title", "summary", "url", "10-5-2020");
      Assert.AreEqual(newArticle, newArticle2);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ArticleList()
    {
      Article newArticle = new Article(1, "source", "author", "title", "summary", "url", "10-5-2020");
      newArticle.Save();
      List<Article> result = Article.GetAll();
      List<Article> testList = new List<Article>{ newArticle };
      CollectionAssert.AreEqual(result, testList);
    }
  }
}