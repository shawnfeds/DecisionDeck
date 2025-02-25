using DecisionDeck.DataAccessObjects;
using DecisionDeck.Models;

namespace DecisionDeck.Contracts
{
    public interface IUserRepository: IDecisionRepository<User>
    {
        public User GetUserbyUsernamePassword(UserDTO user);
        public bool HasUser(UserDTO user);
    }
}
