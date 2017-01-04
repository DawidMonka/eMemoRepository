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
    class TestUserManagement
    {
        private DataBaseConnection dbConnection = new DataBaseConnection();
        private UsersManagement usersManagement = new UsersManagement(); 


        
        private void CreateNewUser()
        {
            RegistrationEntity entity = new RegistrationEntity(true);
            entity.Nick = "test";
            entity.Pass = "test";
            entity.Name = "test";
            entity.Surname = "test";

            entity.insertNewUser(dbConnection);
        }

        [TestMethod]
        public void MustPassWhenDeleted()
        {
            bool ifContains = false;
            CreateNewUser();
            var rows = usersManagement.getUsers().Tables[0].Rows;
            ifContains = rows.Contains("test");
            Assert.IsTrue(ifContains);
            //usersManagement.deleteUser("test");
        }
    }
}
