using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;

namespace DecisionDeck.Contracts
{
    public interface IAlreadyVotedRepository: IDecisionRepository<AlreadyVoted>
    {
        public bool HasVoted(AlreadyVotedDTO votedDTO);
    }
}
