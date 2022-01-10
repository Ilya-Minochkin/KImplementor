using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUsersRepository
    {
        public User GetUserById(long id);
        public Task<User> GetUserByIdAsync(long id);
        public User GetUserByEmail(string email);
        public void SaveUser(User user);
        public IEnumerable<User> GetAllUsers();
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public void DeleteUser(User user);
    }
}
