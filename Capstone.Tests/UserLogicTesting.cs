using System;
using System.Collections.Generic;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
namespace UnitUserLogicTest
{
    [TestClass]
    public class UserLogicTesting
    {
        private List<UserSM> MockUser = new List<UserSM>()
        {
          new UserSM {UserId=1,Username="Mac",Password="Pass1", Admin=true, Poweruser=false, User=false,
              Street1="123 Azalea Ln.",Street2="apt4", City="Reidsville", State="GA.", Zipcode=30453},
          new UserSM {UserId=2,Username="And",Password="Pass1", Admin=false, Poweruser=true, User=false,
              Street1="132 Azalea Ln.",Street2="apt2", City="Reidsville", State="GA.", Zipcode=30453},
          new UserSM {UserId=3,Username="Cheese",Password="Pass1", Admin=false, Poweruser=false, User=true,
              Street1="321 Azalea Ln.",Street2="apt0", City="Reidsville", State="GA.", Zipcode=30453}
        };
        [TestMethod]
        public void TestGetUser()
        {
            MockRepository mocks = new MockRepository();
            IUserLogic logic = mocks.Stub<IUserLogic>();
            UserSM user1 = new UserSM();
            using (mocks.Record())
            {
                SetupResult.For(logic.GetUser(user1)).Return(user1);
            }
            //Act
            UserSM user2 = logic.GetUser(user1);
            //Assert
            Assert.AreEqual(user1, user2);
        }
        [TestMethod]
        public void TestGetUsers()
        {
            //Arange
            MockRepository mocks = new MockRepository();
            IUserLogic logic = mocks.Stub<IUserLogic>();
            using (mocks.Record())
            {
                SetupResult.For(logic.GetUsers()).Return(MockUser);
            }
            //Act
            List<UserSM> users = logic.GetUsers();
            //Assert
            Assert.AreEqual(MockUser.Count, users.Count);
        }
        [TestMethod]
        public void TestCheckUsername()
        {
            //Arange
            MockRepository mocks = new MockRepository();
            IUserLogic logic = mocks.Stub<IUserLogic>();
            string username1 = "meowgurl123";
            using (mocks.Record())
            {
                SetupResult.For(logic.CheckUsername(username1)).Return(true);
            }
            //Act
            bool value = logic.CheckUsername(username1);
            //Assert
            Assert.AreEqual(true, value);
        }
        [TestMethod]
        public void TestLogin()
        {
            //Arange
            MockRepository mocks = new MockRepository();
            IUserLogic logic = mocks.Stub<IUserLogic>();
            UserSM user1 = new UserSM();
            using (mocks.Record())
            {
                SetupResult.For(logic.Login(user1)).Return(true);
            }
            //Act
            bool value = logic.Login(user1);
            //Assert
            Assert.AreEqual(true, value);
        }
        [TestMethod]
        public void TestCreateUser()
        {
            //Arange
            MockRepository mocks = new MockRepository();
            IUserLogic logic = mocks.Stub<IUserLogic>();
            UserSM user1 = new UserSM();
            using (mocks.Record())
                //Act
                logic.CreateUser(user1);
                //Assert
                verify(logic, times(1)).CreateUser(user1);

        }
        [TestMethod]
        public void TestGetUserById()
        {
            //Arange
            MockRepository mocks = new MockRepository();
            IUserLogic logic = mocks.Stub<IUserLogic>();
            int Id = 1;
            int secId = 2;
            UserSM User = new UserSM();
            User.UserId = 1;
            User.Username = "Abin";
            UserSM secUser = new UserSM();
            secUser.UserId = 2;
            secUser.Username = "Cody";
            using (mocks.Record())
            {
                SetupResult.For(logic.GetUserById(Id)).Return(User);
                SetupResult.For(logic.GetUserById(secId)).Return(secUser);
            }
            //Act
            UserSM mockUser = logic.GetUserById(Id);
            //Assert
            Assert.AreEqual("Abin", mockUser.Username);
        }
    }
}
