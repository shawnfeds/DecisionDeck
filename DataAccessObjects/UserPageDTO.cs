using DecisionDeck.Models;

namespace DecisionDeck.DataAccessObjects
{
    public class UserPageDTO
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public int ActiveUserCount { get; set; }
        public int InActiveUserCount { get; set; }
        public int TotalUserCount { get; set; }
    }
}
