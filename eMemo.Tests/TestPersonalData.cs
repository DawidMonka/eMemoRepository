using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eMemo.Helpers;

namespace eMemo.Tests
{
    /// <summary>
    /// Klasa testująca metody klasy Helpers.PersonalData
    /// </summary>
    [TestClass]
    public class TestPersonalData
    {
        PersonalData personalData; 
        
        [TestInitialize]
        public void TestInitialize()
        {
            personalData = new PersonalData(TestUser.Nick);
            personalData.Name = TestUser.Name;
            personalData.Surname = TestUser.Surname;
            personalData.Sex = TestUser.Sex;
            personalData.City = TestUser.City;
            personalData.BirthDate = TestUser.BirthDate;
        }
        
        [TestMethod]
        public void MustPassWhenGetCorrectFormatOfBirthDate()
        {
            var correctBirthDate = "1980-12-12";
            var result = "";

            result = (string) personalData.getBirthDate();

            Assert.AreEqual(result, correctBirthDate);
        }

        [TestMethod]
        public void MustFailWhenGetWrongFormatOfBirthDate()
        {
            var wrongBirthDate = "1980-12-12 00:00:00";
            var result = "";

            result = (string)personalData.getBirthDate();

            Assert.AreNotEqual(result, wrongBirthDate);
        }

        [TestMethod]
        public void MustPassWhenMustGetAllDataFromDataBaseWithDataIsNotComplete()
        {
            personalData.DataIsComplete = false;
            bool result;

            result = personalData.getAllDataFromDataBase();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenMustGetAllDataFromDataBaseWithCompleteData()
        {
            personalData.DataIsComplete = true;
            bool result;

            result = personalData.getAllDataFromDataBase();

            Assert.IsFalse(result);
        }
    }
}
