// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using NewsGator.Models;
// using System;
// using System.Collections.Generic;

// namespace NewsGator.Tests
// {
//   [TestClass]
//   public class KeywordTests
//   {
//     [TestMethod]
//     public void WordBreak_CanDivideAWord_WordArray()
//     {
//       string phrase = "Hello World, this is a test";
//       string[] expectation = new string[] {"hello", "world", "this", "is", "a", "test"};
//       string[] result = Keyword.WordBreak(phrase);
//       CollectionAssert.AreEqual(result, expectation);
//     }

//     [TestMethod]
//     public void Keyphrase_CanAssembleKeyphrasesAroundStopWord_PhraseArray()
//     {
//       string[] parsePhrase = new string[] {"hello", "world", "this", "is", "a", "test"};
//       ICollection<string> expectation = new HashSet<string>{ "world", "test"};
//       ICollection<string> results = Keyword.Keyphrase(parsePhrase);
//       CollectionAssert.AreEqual(results, expectation);
//     }

//     [TestMethod]
//     public void Keyphrase_CanCombineTheAboveMethods_PhraseArray()
//     {
//       string phrase = "Two scoops of Ice Cream";
//       string[] parsePhrase = Keyword.WordBreak(phrase);
//       List<string> results = Keyword.Keyphrase(parsePhrase);
//       List<string> expectation = new List<string>{ "scoops", "ice", "cream", "ice cream"};
//       foreach(string word in results)
//       {
//         Console.WriteLine(word);
//       }
//       CollectionAssert.AreEqual(results, expectation);
//     }
//   }
// }