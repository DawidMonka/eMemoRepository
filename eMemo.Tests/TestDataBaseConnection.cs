using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoGameSite.Helpers;
using eMemo.Tests;
using eMemo.Helpers;

namespace UnitTestLoginSite
{
    /// <summary>
    /// Klasa testująca metody klasy Helpers.DataBaseConnection
    /// </summary>
    [TestClass]
    public class TestDataBaseConnection
    {
        DataBaseConnection connection;

        [TestInitialize]
        public void startDataBaseConnection()
        {
            connection = new DataBaseConnection();
            //connection.openConnection();
        }

        [TestCleanup]
        public void finishDataBaseConection()
        {
            if(connection.isConnectionOpen())
            {
                connection.closeConnection();
            }
        }
        
        
        [TestMethod]
        public void MustPassWhenConnectionIsOpen()
        {
            //DataBaseConnection dataBaseConnection = new DataBaseConnection();
            //dataBaseConnection.openConnection();
            //startDataBaseConnection();
            connection.openConnection();
            bool result;

            result = connection.isConnectionOpen();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenConnectionIsNotOpen()
        {
            //DataBaseConnection dataBaseConnection = new DataBaseConnection();
            //dataBaseConnection.closeConnection();
            //startDataBaseConnection();
            connection.closeConnection();
            bool result;

            result = connection.isConnectionOpen();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenGetCorrectNameFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.Name;
            var nick = TestUser.Nick;
            var name = TestUser.Name;
            var result = "";

            result = (string) connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void MustFailWhenGetWrongNameFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.Name;
            var nick = TestUser.Nick;
            var name = "WrongName";
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreNotEqual(name, result);
        }

        [TestMethod]
        public void MustPassWhenGetCorrectSurnameFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.Surname;
            var nick = TestUser.Nick;
            var surname = TestUser.Surname;
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreEqual(surname, result);
        }

        [TestMethod]
        public void MustFailWhenGetWrongSurnameFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.Surname;
            var nick = TestUser.Nick;
            var surname = "WrongSurname";
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreNotEqual(surname, result);
        }

        [TestMethod]
        public void MustPassWhenGetCorrectSexFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.Sex;
            var nick = TestUser.Nick;
            var sex = TestUser.Sex;
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreEqual(sex, result);
        }

        [TestMethod]
        public void MustFailWhenGetWrongSexFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.Sex;
            var nick = TestUser.Nick;
            var sex = "WrongSex";
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreNotEqual(sex, result);
        }

        [TestMethod]
        public void MustPassWhenGetCorrectCityFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.City;
            var nick = TestUser.Nick;
            var city = TestUser.City;
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreEqual(city, result);
        }

        [TestMethod]
        public void MustFailWhenGetWrongCityFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.City;
            var nick = TestUser.Nick;
            var city = "WrongCity";
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreNotEqual(city, result);
        }

        [TestMethod]
        public void MustPassWhenGetCorrectBirthDateFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.BirthDate;
            var nick = TestUser.Nick;
            var birthDate = TestUser.BirthDate;
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreEqual(birthDate, result);
        }

        [TestMethod]
        public void MustFailWhenGetWrongBirthDateFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.BirthDate;
            var nick = TestUser.Nick;
            var birthDate = "1900-01-01 00:00:00";
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreNotEqual(birthDate, result);
        }

        [TestMethod]
        public void MustPassWhenGetCorrectRegDateFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.RegDate;
            var nick = TestUser.Nick;
            var regDate = TestUser.RegDate;
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreEqual(regDate, result);
        }

        [TestMethod]
        public void MustFailWhenGetWrongRegDateFromDataBaseUsingNick()
        {
            var column = DataBaseConstants.UserTable.RegDate;
            var nick = TestUser.Nick;
            var regDate = "1900-01-01 00:00:00";
            var result = "";

            result = (string)connection.getStringValueFromDataBaseUsingNick(column, nick);

            Assert.AreNotEqual(regDate, result);
        }
    }
}
