using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Size
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
