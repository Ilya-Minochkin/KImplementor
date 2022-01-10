using DataLayer.Entities;
using DataLayer.Exceptions;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Implementations
{
    public class EFUsersRepository : IUsersRepository
    {
        private readonly EFDBContext _context;
        public EFUsersRepository(EFDBContext context)
        {
            _context = context;
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public User GetUserByEmail(string email)
        {
            var result = _context.Users.FirstOrDefault(x => x.Email == email);
            if (result == null)
                throw new UserNotFoundException($"User with email {email} not found");
            return result;
        }

        public User GetUserById(long id)
        {
            var result = _context.Users.Find(id);
            if (result == null)
                throw new UserNotFoundException($"User with id {id} not found");
            return result;
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            var result = await _context.Users.FindAsync(id);
            if (result == null)
                throw new UserNotFoundException($"User with id {id} not found");
            return result;
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                _context.Users.Update(user);
            }
            _context.SaveChanges();
        }
    }
}
