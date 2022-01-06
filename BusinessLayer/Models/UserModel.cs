using DataLayer.Entities;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public User User { get; set; }
        public UserModel()
        {
            User = new User();
        }
        public UserModel(User user)
        {
            User = user;
        }
    }
}