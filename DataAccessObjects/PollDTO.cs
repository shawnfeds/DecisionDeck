namespace DecisionDeck.DataAccessObjects
{
    public class PollDTO
    {
        public int PollId { get; set; }
        public string PollName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime PollEndDate { get; set; }

        public int? GroupId { get; set; }

        public List<string> OptionList { get; set; } = new List<string>();

        public bool AlreadyVoted { get; set; }
    }
}
