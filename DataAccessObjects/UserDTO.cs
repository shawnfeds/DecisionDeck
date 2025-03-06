using DecisionDeck.Models;

namespace DecisionDeck.DataAccessObjects
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleID { get; set; } = 2;
        public int GroupID { get; set; } = 11;
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
