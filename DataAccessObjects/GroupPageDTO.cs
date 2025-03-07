using DecisionDeck.Models;

namespace DecisionDeck.DataAccessObjects
{
    public class GroupPageDTO
    {
        public IEnumerable<Group> Groups { get; set; } = new List<Group>();
        public int ActiveGroupCount { get; set; }
        public int InActiveGroupCount { get; set; }
        public int TotalGroupCount { get; set; }
    }
}
