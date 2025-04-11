using System;
using System.Collections.Generic;

namespace WPFAppLibrary.Models;

public partial class DistributingBook
{
    public int Id { get; set; }

    public int IdBook { get; set; }

    public int IdReader { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual Reader IdReaderNavigation { get; set; } = null!;
}
