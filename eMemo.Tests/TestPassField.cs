using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoGameSite;
using System.Data.SqlClient;
using System.Configuration;
using MemoGameSite.Helpers;

namespace UnitTestLoginSite
{
    [TestClass]
    public class TestPassField
    {    
        /// <summary>
        /// Klasa testująca metody klasy Helpers.PassField
        /// </summary>
        [TestMethod]
        public void MustPassWhenPasswordIsCorrect()
        {
            //zmiana jakas
            string nick = "Admin";
            string pass = "admin";
            PassField passField = new PassField();
            bool result = false;

            result = passField.isPasswordCorrect(nick, pass);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustPassWhenPasswordIsNotCorrect()
        {
            string nick = "Admin";
            string pass = "$$$$$";
            PassField passField = new PassField();
            bool result = false;

            result = passField.isPasswordCorrect(nick, pass);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenNoPass()
        {
            string emptyPass = "";
            PassField passField = new PassField();
            bool result = false;

            result = passField.isEmpty(emptyPass);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenNoPass()
        {
            string pass = "pass01";
            PassField passField = new PassField();
            bool result = false;

            result = passField.isEmpty(pass);

            Assert.IsFalse(result);
        }
    }
}
