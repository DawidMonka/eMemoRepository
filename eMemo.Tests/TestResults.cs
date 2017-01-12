 using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoGameSite.Helpers;
using System.Data;
using eMemo.Helpers;

namespace eMemo.Tests
{
    /// <summary>
    /// Klasa testująca metody klasy Helpers.Result
    /// </summary>
    [TestClass]
    public class TestResults
    {
        //nick użytkownika testowego, klasa TestUser
        private const string nick = TestUser.Nick;
        
        //private const string nickFail = "b";
        Results results = new Results();


        [TestMethod]

        public void MustPassWhenFirstPointScoreIsBetterThanSecond()
        {

            var rows = results.getResults(DataBaseConstants.BoardNoValue.FourFive,DataBaseConstants.GameModeValue.PointsMode).Tables[0].Rows;
            
            var firstResult = (int)rows[0]["lPkt"];
            var secondResult = (int)rows[1]["lPkt"];

            var order = firstResult >= secondResult;

            Assert.IsTrue(order);
        }

        [TestMethod]
        public void MustPassWhenFirstTimeIsLessThanSecond()
        {

            var rows = results.getResults(DataBaseConstants.BoardNoValue.FourFour, DataBaseConstants.GameModeValue.TimeMode).Tables[0].Rows;

            var firstResult = (float)rows[0]["czasTrwania"];
            var secondResult = (float)rows[1]["czasTrwania"];

            var order = firstResult <= secondResult;

            Assert.IsTrue(order);
        }

        [TestMethod]
        public void MustPassWhenNicksAreEqualByPoints()
        {

            var rows = results.getResultsByNick(DataBaseConstants.BoardNoValue.FourFour, DataBaseConstants.GameModeValue.PointsMode,nick).Tables[0].Rows;

            var firstResult = (string)rows[0]["gracz"];
            var secondResult = (string)rows[1]["gracz"];

            var ifEqual = firstResult == secondResult;
            Assert.IsTrue(ifEqual);
        }

        [TestMethod]
        public void MustPassWhenNicksAreEqualByTime()
        {

            var rows = results.getResultsByNick(DataBaseConstants.BoardNoValue.FourFour, DataBaseConstants.GameModeValue.TimeMode,nick).Tables[0].Rows;

            var firstResult = (string)rows[0]["gracz"];
            var secondResult = (string)rows[1]["gracz"];

            var ifEqual = firstResult == secondResult;
            Assert.IsTrue(ifEqual);
        }

        [TestMethod]
        public void MustPassWhenNickAByPoints()
        {
            var rows = results.getResultsByNick(DataBaseConstants.BoardNoValue.FourFour, DataBaseConstants.GameModeValue.PointsMode,nick).Tables[0].Rows;

            var firstResult = (string)rows[0]["gracz"];
            var ifEqual = firstResult == nick;
            Assert.IsTrue(ifEqual);
        }

        [TestMethod]
        public void MustPassWhenNickAByTime()
        {
            var rows = results.getResultsByNick(DataBaseConstants.BoardNoValue.FourFive, DataBaseConstants.GameModeValue.TimeMode,nick).Tables[0].Rows;

            var firstResult = (string)rows[0]["gracz"];
            var ifEqual = firstResult == nick;
            Assert.IsTrue(ifEqual);
        }
    }
}
