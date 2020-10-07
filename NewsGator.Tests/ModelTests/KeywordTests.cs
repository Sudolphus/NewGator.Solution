using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsGator.Models;
using System;
using System.Collections.Generic;

namespace NewsGator.Tests
{
  [TestClass]
  public class KeywordTests
  {
    [TestMethod]
    public void WordBreak_CanDivideAWord_WordArray()
    {
      string phrase = "Hello World, this is a test";
      string[] expectation = new string[] {"hello", "world", "this", "is", "a", "test"};
      string[] result = Keyword.WordBreak(phrase);
      CollectionAssert.AreEqual(result, expectation);
    }

    [TestMethod]
    public void Keyphrase_CanAssembleKeyphrasesAroundStopWord_PhraseArray()
    {
      string[] parsePhrase = new string[] {"hello", "world", "this", "is", "a", "test"};
      List<string> expectation = new List<string>{ "world", "test"};
      List<string> results = Keyword.Keyphrase(parsePhrase);
      CollectionAssert.AreEqual(results, expectation);
    }
  }
}