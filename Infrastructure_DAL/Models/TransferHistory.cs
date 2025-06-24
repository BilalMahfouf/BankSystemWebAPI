using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class TransferHistory
{
    public int TransferID { get; set; }

    public int FromClientID { get; set; }

    public int ToClientID { get; set; }

    public DateTime TransferDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int CreatedByUserID { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual Client FromClient { get; set; } = null!;

    public virtual Client ToClient { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
