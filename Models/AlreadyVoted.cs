using System;
using System.Collections.Generic;

namespace DecisionDeck.Models;

public partial class AlreadyVoted
{
    public int AlreadyVotedId { get; set; }

    public int UserId { get; set; }

    public int PollId { get; set; }

    public virtual Poll Poll { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
