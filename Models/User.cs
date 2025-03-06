using System;
using System.Collections.Generic;

namespace DecisionDeck.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public int? GroupId { get; set; }

    public virtual ICollection<AlreadyVoted> AlreadyVoteds { get; set; } = new List<AlreadyVoted>();

    public virtual Group? Group { get; set; }

    public virtual ICollection<Poll> Polls { get; set; } = new List<Poll>();

    public virtual Role? Role { get; set; }
}
