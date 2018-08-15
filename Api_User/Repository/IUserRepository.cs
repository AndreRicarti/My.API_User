using Api_User.Models;
using System.Collections.Generic;

namespace Api_User.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(long id);
        void Remove(long id);
        void Update(User user);
    }
}
