namespace DecisionDeck.DataAccessObjects
{
    public class VoteDTO
    {
        public int PollId { get; set; }  
        public int UserId { get; set; }  
        public string OptionName { get; set; }
    }
}
