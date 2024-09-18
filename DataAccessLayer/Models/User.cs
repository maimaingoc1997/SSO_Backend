using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Phone { get; set; }

    public int? Gender { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
