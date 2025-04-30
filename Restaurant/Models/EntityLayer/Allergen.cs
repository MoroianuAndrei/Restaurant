using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class Allergen
{
    public int AllergenId { get; set; }

    public string AllergenName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
