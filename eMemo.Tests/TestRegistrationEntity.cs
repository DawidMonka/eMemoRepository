using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using MemoGameSite.Helpers;

namespace UnitTestLoginSite
{
    /// <summary>
    /// Klasa testująca metody klasy Helers.RegistrationEntity
    /// </summary>
    [TestClass]
    public class TestRegistrationEntity
    {
        private RegistrationEntity regEntity;
        private bool isReady = true;
        private bool isNotReady = false;
        private string notEmptyValue = "value";
        private string emptyValue = "";
        
        [TestInitialize]
        private void SetTestData(bool readyOrNot)
        {
            regEntity = new RegistrationEntity(readyOrNot);
        }
        
        [TestMethod]
        public void MustPassWhenIsReadyToRegistrate()
        {
            SetTestData(isReady);
            bool result;

            result = regEntity.IsReadyToRegistrate();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenIsNotReadyToRegistrate()
        {
            SetTestData(isNotReady);
            bool result;

            result = regEntity.IsReadyToRegistrate();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenValueIsEmpty()
        {
            SetTestData(isReady);
            bool result;

            result = regEntity.isValueEmpty(emptyValue);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenValueIsNotEmpty()
        {
            SetTestData(isReady);
            bool result;

            result = regEntity.isValueEmpty(notEmptyValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustPassWhenNoValueIsEmpty()
        {
            SetTestData(isReady);
            SetAllValuesForRegistrationEntity(notEmptyValue,notEmptyValue);
            bool result;

            result = regEntity.noValueIsEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MustFailWhenAllValuesAreEmpty()
        {
            SetTestData(isReady);
            SetAllValuesForRegistrationEntity(emptyValue,emptyValue);
            bool result;

            result = regEntity.noValueIsEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MustFailWhenSomeValuesAreEmpty()
        {
            SetTestData(isReady);
            SetAllValuesForRegistrationEntity(notEmptyValue,emptyValue);
            bool result;

            result = regEntity.noValueIsEmpty();

            Assert.IsFalse(result);
        }

        private void SetAllValuesForRegistrationEntity(string value1, string value2)
        {
            regEntity.Nick = value1;
            regEntity.Pass = value2;
            regEntity.AcceptTerms = true;
            //regEntity.Name = value1;
            //regEntity.Surname = value2;
            //regEntity.Sex = value1;
            //regEntity.City = value2;
        }
    }
}
