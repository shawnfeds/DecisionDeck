using System;
using System.Collections.Generic;

namespace DecisionDeck.Models;

public partial class PollOption
{
    public int PollOptionId { get; set; }

    public int? PollId { get; set; }

    public string OptionName { get; set; } = null!;

    public int? SelectedCount { get; set; }

    public virtual Poll? Poll { get; set; }
}
