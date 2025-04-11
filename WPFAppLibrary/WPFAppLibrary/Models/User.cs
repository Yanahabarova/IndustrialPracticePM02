using System;
using System.Collections.Generic;

namespace WPFAppLibrary.Models;

public partial class User
{
    public int Id { get; set; }

    public int? IdReader { get; set; }

    public int IdRole { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Reader? IdReaderNavigation { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
