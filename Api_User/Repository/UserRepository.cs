using Api_User.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api_User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Add(User user)
        {
            userDbContext.User.Add(user);
            userDbContext.SaveChanges();
        }

        public User Find(long id)
        {
            return userDbContext.User.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return userDbContext.User.ToList();
        }

        public void Remove(long id)
        {
            var entity = userDbContext.User.First(u => u.Id == id);
            userDbContext.User.Remove(entity);
            userDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            userDbContext.User.Update(user);
            userDbContext.SaveChanges();
        }
    }
}
