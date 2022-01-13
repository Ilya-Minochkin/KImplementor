using BusinessLayer.Services;
using BusinessLayer.Utils;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Exceptions;
using DataLayer.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KImplementorTests.BusinessLayerTests
{
    public class UserServiceTests
    {
        private string email;
        private string wrongEmail;
        private Mock<IUsersRepository> mock;
        private UserService service;

        public UserServiceTests()
        {
            InitData();
        }
        [Test]
        public void ShouldThrowExceptionIfUserNotExists()
        {
            var ex = Assert.Throws<UserNotFoundException>(() => service.GetUserModelByEmail(wrongEmail));
            Assert.That(ex.Message, Is.EqualTo("Exception of type 'DataLayer.Exceptions.UserNotFoundException' was thrown."));
        }

        private void InitData()
        {
            email = "Test1@test";
            wrongEmail = "wrongEmail@w.com";
            mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetAllUsers())
                .Returns(GetPreparedUsers());
            mock.Setup(repo => repo.GetUserByEmail(email))
                .Returns(GetPreparedUsers()
                    .Where(user => user.Email == email)
                    .FirstOrDefault);
            mock.Setup(repo => repo.GetUserByEmail(wrongEmail))
                .Throws(new UserNotFoundException());
            service = new UserService(new DataManager(usersRepository: mock.Object));
        }

        private List<User> GetPreparedUsers()
        {
            var result = new List<User>();
            var hasher = new Hasher();
            for (int i = 1; i <= 10; i++)
            {
                result.Add(new User()
                {
                    Id = i,
                    Email = $"Test{i}@test",
                    FullName = $"Test{i}",
                    Password = hasher.GetHashedStringSha3($"Test{i}"),
                    ShortName = $"T{i}"
                });
            }


            return result;
        }
    }
}
