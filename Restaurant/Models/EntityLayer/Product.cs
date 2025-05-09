using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal PortionQuantity { get; set; }

    public string MeasurementUnit { get; set; } = null!;

    public decimal TotalQuantity { get; set; }

    public int CategoryId { get; set; }

    public bool? IsMenu { get; set; }

    public string? ImagePath { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Allergen> Allergens { get; set; } = new List<Allergen>();
}
