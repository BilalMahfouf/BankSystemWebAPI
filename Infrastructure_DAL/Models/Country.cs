using System;
using System.Collections.Generic;

namespace Infrastructure_DAL.Models;

public partial class Country
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
