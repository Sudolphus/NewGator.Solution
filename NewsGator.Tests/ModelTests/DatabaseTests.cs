using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using NewsGator.Models;
using System;

namespace NewsGator.Tests
{
  [TestClass]
  public class DatabaseTests : IDisposable
  {
    public void Dispose()
    {
      Article.ClearAll();
    }
  }
}