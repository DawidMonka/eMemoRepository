 using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoGameSite.Helpers;
using System.Data;

namespace eMemo.Tests
{
    /// <summary>
    /// Klasa testująca metody klasy Helpers.Result
    /// </summary>
    [TestClass]
    public class TestResults
    {
        private const int wielkosc = 45;
        Results results = new Results(wielkosc);
        
        [TestMethod]
        
        public void MustPassWhenFirstPointScoreIsBetterThanSecond()
        {
            
            var rows = results.getResultsByPoints().Tables[0].Rows;

            var firstResult = (int)rows[0]["lPkt"];
            var secondResult = (int)rows[1]["lPkt"];

            var order = firstResult >= secondResult;

            Assert.IsTrue(order);
        }

        [TestMethod]
        public void MustPassWhenFirstTimeIsLessThanSecond()
        {
            
            var rows = results.getResultsByTime().Tables[0].Rows;

            var firstResult = (float)rows[0]["czasTrwania"];
            var secondResult = (float)rows[1]["czasTrwania"];

            var order = firstResult <= secondResult;

            Assert.IsTrue(order);
        }
    }
}
