using BusinessLayer.Models;
using BusinessLayer.Utils;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;

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
            var password = userModel.User.Password;


            userModel.User.Password = hasher.GetHashedStringSha3(password);
            _usersRepository.SaveUser(userModel.User);
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
