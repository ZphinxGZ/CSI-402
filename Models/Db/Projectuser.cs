using System;
using System.Collections.Generic;

namespace CSI402.Models.Db;

public partial class Projectuser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
