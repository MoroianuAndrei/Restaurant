using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImagePath { get; set; } = null!;

    public string? ImageDescription { get; set; }

    public virtual Product Product { get; set; } = null!;
}
