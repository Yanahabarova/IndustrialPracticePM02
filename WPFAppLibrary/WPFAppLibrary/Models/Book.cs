using System;
using System.Collections.Generic;

namespace WPFAppLibrary.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Cipher { get; set; } = null!;

    public int? IdAuthor { get; set; }

    public string Name { get; set; } = null!;

    public int? YearOfPublication { get; set; }

    public int? NumberOfCopies { get; set; }

    public virtual ICollection<DistributingBook> DistributingBooks { get; set; } = new List<DistributingBook>();

    public virtual Author? IdAuthorNavigation { get; set; }
}

public partial class Book
{
    public string FullInf
    {
        get
        {
            return $"{Name}  {IdAuthorNavigation.Surname} {IdAuthorNavigation.Name.Substring(0,1)}{"."}";
        }
    }
}
