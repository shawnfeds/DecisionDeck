using System;
using System.Collections.Generic;

namespace DecisionDeck.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Poll> Polls { get; set; } = new List<Poll>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
