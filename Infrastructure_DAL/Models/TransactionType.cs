using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class TransactionType
{
    public int TransactionTypeID { get; set; }

    public string TransactionName { get; set; } = null!;

    public decimal TransactionFees { get; set; }

    public string? TransactionDescription { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
