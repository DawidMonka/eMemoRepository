using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoGameSite.Helpers;

namespace eMemo.Tests
{
    /// <summary>
    /// Klasa testująca metody klasy Helpers.NickField
    /// </summary>
    [TestClass]
    public class TestNickField
    {
        const string adminNick = "Admin";
        const string wrongNick = "$$$$$";

        [TestMethod]
        public void MustPassWhenNickFoundInDataBase()
        {
            NickField nickField = new NickField();
            bool result = false;

            result = nickField.checkIfNickInDataBase(adminNick);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenNickNotFoundInDataBase()
        {
            NickField nickField = new NickField();
            bool result = false;

            result = nickField.checkIfNickInDataBase(wrongNick);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenNickIsAdmin()
        {
            NickField nickField = new NickField();
            bool result = false;

            result = nickField.isAdminNick(adminNick);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenNickIsAdmin()
        {
            NickField nickField = new NickField();
            bool result = false;

            result = nickField.isAdminNick(wrongNick);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenNickIsEmpty()
        {
            string emptyNick = "";
            NickField nickField = new NickField();
            bool result = false;

            result = nickField.isEmpty(emptyNick);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenNickIsEmpty()
        {
            NickField nickField = new NickField();
            bool result = false;

            result = nickField.isEmpty(adminNick);

            Assert.IsFalse(result);
        }
    }
}
