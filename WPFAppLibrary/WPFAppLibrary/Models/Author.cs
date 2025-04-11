using System;
using System.Collections.Generic;

namespace WPFAppLibrary.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

public partial class Author
{
    public string FIO
    {
        get
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}
