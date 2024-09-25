using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public int IsWishlist { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
