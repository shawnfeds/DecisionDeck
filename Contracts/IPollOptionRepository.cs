using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;

namespace DecisionDeck.Contracts
{
    public interface IPollOptionRepository: IDecisionRepository<PollOption>
    {
        public List<PollOption> GetByPollId(int pollId);
        public PollOption GetByPollIdAndOptionName(VoteDTO voteDTO);
    }
}
