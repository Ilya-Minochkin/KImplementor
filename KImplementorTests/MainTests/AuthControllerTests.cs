using BusinessLayer;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Interfaces;
using KImplementor.Controllers;
using KImplementor.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KImplementorTests.MainTests
{
    public class AuthControllerTests
    {
        private string email;
        private string password;
        private Mock<IUsersRepository> mock;
        private User testUser;
        private AuthController controller;

        public AuthControllerTests()
        {
            InitData();
        }

        [Test]
        public void SimpleLoginTestSuccessfull()
        {
            var result = controller.Login(email, password);
            var jsonResult = result as JsonResult;
            var loginResponse = jsonResult.Value;

            Assert.IsInstanceOf(typeof(LoginResponse), loginResponse);
        }
        
        [Test]
        public void SimpleLoginTestFailed()
        {
            var wrongPassword = "wrongPwd";
            var result = controller.Login(email, wrongPassword);

            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public void IsItReallyThisUserTest()
        {
            var result = controller.Login(email, password);
            var jsonResult = result as JsonResult;
            var loginResponse = jsonResult.Value as LoginResponse;

            Assert.AreEqual(email, loginResponse.Email);
        }

        private void InitData()
        {
            email = "Test@test.com";
            password = "test";

            mock = new Mock<IUsersRepository>();

            testUser = new User()
            {
                Id = 10,
                Email = email,
                FullName = "Test",
                ShortName = "T",
                Password = "9ece086e9bac491fac5c1d1046ca11d737b92a2b2ebd93f005d7b710110c0a678288166e7fbe796883a4f2e9b3ca9f484f521d0ce464345cc1aec96779149c14",
                Roles = new List<Role>() { new Role { Id = 1, Name = Roles.Admin, Users = null } }
            };

            mock.Setup(x => x.GetUserByEmail(email)).Returns(testUser);
            var dataManager = new DataManager(usersRepository: mock.Object);

            controller = new AuthController(new ServiceManager(dataManager));
        }
    }
}
