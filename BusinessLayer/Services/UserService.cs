using BusinessLayer.Models;
using BusinessLayer.Utils;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Exceptions;
using DataLayer.Interfaces;
using System;

namespace BusinessLayer.Services
{
    public class UserService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(DataManager dataManager)
        {
            _usersRepository = dataManager.UsersRepository;
        }

        public UserModel GetUserModelById(long id)
        {
            var userDb = _usersRepository.GetUserById(id);
            return ToModel(userDb);
        }

        public void SaveUserModel(UserModel userModel)
        {
            var hasher = new Hasher();

            var userWithHashedPassword = new User()
            {
                Email = userModel.User.Email,
                FullName = userModel.User.FullName,
                Password = hasher.GetHashedStringSha3(userModel.User.Password),
                ShortName = userModel.User.ShortName,
                Roles = userModel.User.Roles
            };

            _usersRepository.SaveUser(userWithHashedPassword);
        }

        public UserModel GetUserModelByEmail(string email)
        {
            var userDb = _usersRepository.GetUserByEmail(email);
            return ToModel(userDb);
        }
        private static UserModel ToModel(User user)
        {
            return new UserModel(user);
        }


    }
}
