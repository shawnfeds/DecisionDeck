using Microsoft.EntityFrameworkCore;
using Serilog;
using DecisionDeck.Models;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;

namespace DecisionDeck.Repositories
{
    public class UserRepository : DecisionRepository<User>, IUserRepository
    {
        public UserRepository(DecisionDeckContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                Log.Information("All records for " + typeof(User).Name);
                return _dbSet.Include(o => o.Group).Include(o => o.Role).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return Enumerable.Empty<User>();
            }
        }

        public User GetById(int id)
        {
            try
            {
                Log.Information("Found " + typeof(User).Name + "with id: " + id);
                return _dbSet.Include(o => o.Group).Include(o => o.Role).FirstOrDefault(u => u.UserId == id);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public User GetUserbyUsernamePassword(UserDTO user)
        {
            try
            {
                Log.Information("Found " + typeof(User).Name + " with id: " + user.Username);
                return _dbSet.Include(o => o.Group).Include(o => o.Role).FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", LogLevel.Error, ex.Message, ex);
                return null;
            }
        }

        public bool HasUser(UserDTO user)
        {
            var foundUser = GetUserbyUsernamePassword(user);
            return foundUser != null;
        }

    }
}
