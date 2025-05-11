using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? MenuId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public bool IsMenu { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
