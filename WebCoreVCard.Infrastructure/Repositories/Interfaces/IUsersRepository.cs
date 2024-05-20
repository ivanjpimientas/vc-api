using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCoreVCard.Domain.Entities;

namespace WebCoreVCard.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        User GetUserByNickname(string nickname);
        bool ExistUser(string name);
        bool ExistUser(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
