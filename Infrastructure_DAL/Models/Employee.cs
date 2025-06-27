using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class Employee
{
    public int EmployeeID { get; set; }

    public int PersonID { get; set; }

    public int JobTitleID { get; set; }

    public decimal Salary { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? CreatedByUserID { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual JobTitle JobTitle { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
