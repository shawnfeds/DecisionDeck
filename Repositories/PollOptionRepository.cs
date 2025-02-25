using Microsoft.EntityFrameworkCore;
using Serilog;
using DecisionDeck.Models;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;

namespace DecisionDeck.Repositories
{
    public class PollOptionRepository : DecisionRepository<PollOption>, IPollOptionRepository
    {
        public PollOptionRepository(DecisionDeckContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<PollOption> GetAll()
        {
            try
            {
                Log.Information("All records for " + typeof(PollOption).Name);
                return _dbSet.Include(o => o.Poll).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return Enumerable.Empty<PollOption>();
            }
        }

        public PollOption GetById(int id)
        {
            try
            {
                Log.Information("Found " + typeof(PollOption).Name + "with id: " + id);
                return _dbSet.Include(o => o.Poll).FirstOrDefault(po => po.PollOptionId == id);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public List<PollOption> GetByPollId(int pollId)
        {
            try
            {
                Log.Information("Found " + typeof(PollOption).Name + "with poll id: " + pollId);
                return _dbSet.Include(o => o.Poll).Where(po => po.PollId == pollId).ToList();
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public PollOption GetByPollIdAndOptionName(VoteDTO voteDTO)
        {
            try
            {
                Log.Information("Found " + typeof(PollOption).Name + "with poll id: " + voteDTO.PollId);
                return _dbSet.Include(o => o.Poll).FirstOrDefault(po => po.PollId == voteDTO.PollId && po.OptionName == voteDTO.OptionName);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}
