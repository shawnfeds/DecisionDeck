namespace DecisionDeck.DataAccessObjects
{
    public class UserDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleID { get; set; } = 2;
        public int GroupID { get; set; } = 11;
    }
}
