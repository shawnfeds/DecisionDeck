using Microsoft.EntityFrameworkCore;
using Serilog;
using DecisionDeck.Models;
using DecisionDeck.Contracts;
using DecisionDeck.DataAccessObjects;

namespace DecisionDeck.Repositories
{
    public class AlreadyVotedRepository : DecisionRepository<AlreadyVoted>, IAlreadyVotedRepository
    {
        public AlreadyVotedRepository(DecisionDeckContext dbContext) : base(dbContext)
        {
        }

        public bool HasVoted(AlreadyVotedDTO votedDTO)
        {
            try
            {
                Log.Information("Found " + typeof(User).Name + " with user id: " + votedDTO.UserId);
                var voted = _dbSet.Include(o => o.Poll).Include(o => o.User).FirstOrDefault(u => u.PollId == votedDTO.PollId && u.UserId == votedDTO.UserId);

                return voted != null;
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", LogLevel.Error, ex.Message, ex);
                return false;
            }
        }
    }
}
