using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class Transaction
{
    public int TransactionID { get; set; }

    public int TransactionTypeID { get; set; }

    public int ClientID { get; set; }

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public byte TransactionStatus { get; set; }

    public string? Notes { get; set; }

    public int CreatedByUserID { get; set; }

    public int? TransferID { get; set; }

    public DateTime CreatedAt { get; set; }

    // to fix  remove this field from db and code 25/06/2025 
    public DateTime UpdatedAt { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual TransactionType TransactionType { get; set; } = null!;

    public virtual TransferHistory? Transfer { get; set; }
}
