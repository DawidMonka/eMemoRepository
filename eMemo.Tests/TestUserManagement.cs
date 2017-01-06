using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using eMemo.Helpers;
using MemoGameSite.Helpers;




namespace eMemo.Tests
{
    [TestClass]
    public class TestUserManagement
    {
        private DataBaseConnection dbConnection = new DataBaseConnection();
        private UsersManagement usersManagement = new UsersManagement();

        String searchNick = "test";

        private void CreateNewUser()
        {
            RegistrationEntity entity = new RegistrationEntity(true);
            entity.Nick = searchNick;
            entity.Pass = searchNick;
            entity.Name = "t";
            entity.Surname = "t";
            entity.AcceptTerms = true;
            entity.BirthDate = DateTime.MinValue;
            entity.Sex = "M";
            entity.City = "test";
            entity.SignDate = DateTime.Now;

            entity.insertNewUser(dbConnection);
        }
        


        [TestMethod]
        public void MustPassWhenDeleted()
        {
            bool ifContains = true;
            CreateNewUser(); 
            usersManagement.deleteUser(searchNick);
            DataTable tbl = usersManagement.getUsers().Tables[0];
            DataRow[] foundValue = tbl.Select("nick = '" + searchNick + "'");
            
            if (foundValue.Length == 0)
            {
                ifContains = false;
            }
           
            
            Assert.IsFalse(ifContains);
            //usersManagement.deleteUser("test");
        }
        [TestMethod]
        public void MustPassWhenGetTrueAfterDeleted()
        {
            CreateNewUser();
            Assert.IsTrue(usersManagement.deleteUser(searchNick));
        }

    }
}
