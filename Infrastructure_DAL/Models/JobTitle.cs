using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class JobTitle
{
    public int JobID { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
