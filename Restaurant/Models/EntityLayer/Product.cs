using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Model.EntityLayer;

namespace Restaurant.Model.EntityLayer;

public sealed class Product
{
    [Key]
    public int? ProductId { get; set; }

    [Required, StringLength(50)]
    public string? Name { get; set; }

    [Required, StringLength(50)]
    public string? Barcode { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int ProducerId { get; set; }

    [StringLength(200)]
    public string? Image { get; set; }

    [DefaultValue(1)]
    public bool? IsActive { get; set; }

    [ForeignKey("CategoryId")]
    //public Category? Category { get; set; }

    //[ForeignKey("ProducerId")]
    //public Producer? Producer { get; set; }

    //public Offer? Offer { get; init; }
    //public ICollection<Stock?>? Stocks { get; init; }

    [NotMapped]
    public ICollection<Receipt?>? Receipts { get; init; }
}