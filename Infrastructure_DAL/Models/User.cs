using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class User
{
    public int UserID { get; set; }

    public int EmployeeID { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Permissions { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<TransferHistory> TransferHistories { get; set; } = new List<TransferHistory>();
}
