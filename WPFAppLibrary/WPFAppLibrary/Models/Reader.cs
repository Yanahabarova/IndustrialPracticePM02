using System;
using System.Collections.Generic;

namespace WPFAppLibrary.Models;

public partial class Reader
{
    public int Id { get; set; }

    public int ReadersCardNumber { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual ICollection<DistributingBook> DistributingBooks { get; set; } = new List<DistributingBook>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

public partial class Reader
{
    public string FIO
    {
        get
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}
