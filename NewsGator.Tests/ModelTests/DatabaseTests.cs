using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsGator.Models;
using System;
using System.Collections.Generic;

namespace NewsGator.Tests
{
  [TestClass]
  // public class DatabaseTests
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

    [TestMethod]
    public void GetAll_FindsAll_ArticleList()
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      string[] valArr2 = new string[4]{"author2", "title2", "summary2", "url2"};
      Article testArticle = new Article("test1", valArr);
      Article testArticle2 = new Article("test2", valArr2);
      testArticle.Save();
      testArticle2.Save();
      List<Article> results = Article.GetAll();
      List<Article> testList = new List<Article>{ testArticle, testArticle2 };
      CollectionAssert.AreEqual(results, testList);
    }

    [TestMethod]
    public void Find_CanFindBySource_ArticleList()
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      string[] valArr2 = new string[4]{"author2", "title2", "summary2", "url2"};
      Article testArticle = new Article("test1", valArr);
      Article testArticle2 = new Article("test2", valArr2);
      testArticle.Save();
      testArticle2.Save();
      // string[] filters = new string[6]{"test1", null, null, null, null, null};
      List<Article> results = Article.Find(new string[6]{"test1", null, null, null, null, null});
      List<Article> testList = new List<Article>{ testArticle };
      CollectionAssert.AreEqual(results, testList);
    }

    [DataRow(new string[6]{"test1", null, null, null, null, null})]
    [DataRow(new string[6]{null, "author", null, null, null, null})]
    [DataRow(new string[6]{null, null, "title", null, null, null})]
    [DataRow(new string[6]{null, null, null, "summary", null, null})]
    [DataRow(new string[6]{null, null, null, null, "url", null})]
    [DataTestMethod]
    public void Find_CanFilterByAnyField_ArticleList(string[] filters)
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      string[] valArr2 = new string[4]{"author2", "title2", "summary2", "url2"};
      Article testArticle = new Article("test1", valArr);
      Article testArticle2 = new Article("test2", valArr2);
      testArticle.Save();
      testArticle2.Save();
      List<Article> results = Article.Find(filters);
      List<Article> testList = new List<Article> { testArticle };
      CollectionAssert.AreEqual(results, testList);
    }

    [TestMethod]
    public void Find_CanFindByDate_ArticleList()
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      string[] valArr2 = new string[4]{"author2", "title2", "summary2", "url2"};
      Article testArticle = new Article("test1", valArr);
      Article testArticle2 = new Article("test2", valArr2);
      testArticle.Save();
      testArticle2.Save();
      List<Article> results = Article.Find(new string[6]{null, null, null, null, null, "10/5/2020"});
      List<Article> testList = new List<Article> { testArticle, testArticle2 };
      CollectionAssert.AreEqual(results, testList);
    }

    [TestMethod]
    public void Find_CanCombineFilters_ArticleList()
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      string[] valArr2 = new string[4]{"author2", "title2", "summary2", "url2"};
      Article testArticle = new Article("test1", valArr);
      Article testArticle2 = new Article("test2", valArr2);
      testArticle.Save();
      testArticle2.Save();
      List<Article> results = Article.Find(new string[6]{"test1", "author", "title", "summary", "url", "10/5/2020"});
      List<Article> testList = new List<Article> { testArticle };
    }

    [TestMethod]
    public void Find_CanHandleNoFilters_ArticleList()
    {
      string[] valArr = new string[4]{"author", "title", "summary", "url"};
      string[] valArr2 = new string[4]{"author2", "title2", "summary2", "url2"};
      Article testArticle = new Article("test1", valArr);
      Article testArticle2 = new Article("test2", valArr2);
      testArticle.Save();
      testArticle2.Save();
      List<Article> results = Article.Find(new string[6]{null, null, null, null, null, null});
      List<Article> testList = new List<Article>{ testArticle, testArticle2 };
      CollectionAssert.AreEqual(results, testList);
    }
  }
}