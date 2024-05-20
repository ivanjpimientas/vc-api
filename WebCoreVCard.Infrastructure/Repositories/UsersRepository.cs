using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCoreVCard.Domain.Entities;
using WebCoreVCard.Infrastructure.Models;
using WebCoreVCard.Infrastructure.Repositories.Interfaces;

namespace WebCoreVCard.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public bool ExistUser(string name)
        {
            bool value = _context.Users.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ExistUser(int id)
        {
            return _context.Users.Any(c => c.Id == id);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(c => c.Name).ToList();
        }

        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(c => c.Id == userId);
        }

        public User GetUserByNickname(string nickname)
        {
            return _context.Users.FirstOrDefault(c => c.Nickname == nickname);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            user.UpdatedAt = DateTime.Now;
            _context.Update(user);
            return Save();
        }
    }
}
