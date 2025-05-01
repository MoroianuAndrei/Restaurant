using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Discount { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}