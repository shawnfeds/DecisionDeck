namespace DecisionDeck.DataAccessObjects
{
    public class ResultDTO
    {
        public PollDTO Poll { get; set; }
        public List<ResultOptionDTO> OptionResults { get; set; } = new List<ResultOptionDTO>();
    }
}
