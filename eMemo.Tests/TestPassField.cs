using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoGameSite;
using System.Data.SqlClient;
using System.Configuration;
using MemoGameSite.Helpers;
using eMemo.Helpers;
using eMemo.Tests;

namespace UnitTestLoginSite
{
    /// <summary>
    /// Klasa testująca metody klasy Helpers.PassField
    /// </summary>
    [TestClass]
    public class TestPassField
    {
        private const string emptyPass = "";
        private const string wrongPass = "$$$%$";

        [TestMethod]
        public void MustPassWhenPasswordIsCorrect()
        {
            NickField nickField = new NickField();
            PassField passField = new PassField();
            string nick = DataBaseConstants.AdminNick;
            string pass = passField.getPasswordFromDataBase(DataBaseConstants.AdminNick);
            bool result = false;

            result = passField.isPasswordCorrect(nick, pass);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustPassWhenPasswordIsNotCorrect()
        {
            string nick = TestUser.Nick;
            string pass = wrongPass;
            PassField passField = new PassField();
            bool result = false;

            result = passField.isPasswordCorrect(nick, pass);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenPassIsEmpty()
        {
            string emptyPassword = emptyPass;
            PassField passField = new PassField();
            bool result = false;

            result = passField.isEmpty(emptyPassword);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenPassIsNotEmpty()
        {
            string pass = TestUser.Password;
            PassField passField = new PassField();
            bool result = false;

            result = passField.isEmpty(pass);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenPassIsConfirmedCorrectly()
        {
            string pass = TestUser.Password;
            string conf = TestUser.Password;
            PassField passField = new PassField();
            var result = false;

            result = (bool) passField.isPasswordCorrectlyConfirmed(pass, conf);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustPassWhenPassIsNotConfirmedCorrectly()
        {
            string pass = TestUser.Password;
            string conf = wrongPass;
            PassField passField = new PassField();
            bool result = true;

            result = (bool) passField.isPasswordCorrectlyConfirmed(pass, conf);

            Assert.IsFalse(result);
        }


    }
}
