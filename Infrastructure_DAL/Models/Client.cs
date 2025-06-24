using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class Client
{
    public int ClientID { get; set; }

    public int PersonID { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string PinCode { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<TransferHistory> TransferHistoryFromClients { get; set; } = new List<TransferHistory>();

    public virtual ICollection<TransferHistory> TransferHistoryToClients { get; set; } = new List<TransferHistory>();

   

}

