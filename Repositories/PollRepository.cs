using Microsoft.EntityFrameworkCore;
using Serilog;
using DecisionDeck.Models;
using DecisionDeck.Contracts;

namespace DecisionDeck.Repositories
{
    public class PollRepository : DecisionRepository<Poll>, IPollRepository
    {
        public PollRepository(DecisionDeckContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Poll> GetAll()
        {
            try
            {
                Log.Information("All records for " + typeof(Poll).Name);
                return _dbSet.Include(o => o.Group).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return Enumerable.Empty<Poll>();
            }
        }

        public Poll GetById(int id)
        {
            try
            {
                Log.Information("Found " + typeof(Poll).Name + "with id: " + id);
                return _dbSet.Include(o => o.Group).FirstOrDefault(p => p.PollId == id);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}
