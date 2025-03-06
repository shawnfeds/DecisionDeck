using System;
using System.Collections.Generic;

namespace DecisionDeck.Models;

public partial class Poll
{
    public int PollId { get; set; }

    public string PollName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime PollEndDate { get; set; }

    public int? GroupId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<AlreadyVoted> AlreadyVoteds { get; set; } = new List<AlreadyVoted>();

    public virtual Group? Group { get; set; }

    public virtual ICollection<PollOption> PollOptions { get; set; } = new List<PollOption>();

    public virtual User? User { get; set; }
}
