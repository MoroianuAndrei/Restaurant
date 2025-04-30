using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class MenuItem
{
    public int MenuId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public virtual Product Menu { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
