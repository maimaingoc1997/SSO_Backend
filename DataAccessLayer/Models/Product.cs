using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int CateId { get; set; }

    public int SizeId { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Cate { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
