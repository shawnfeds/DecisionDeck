namespace DecisionDeck.DataAccessObjects
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
