using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Model.EntityLayer;

public sealed class Receipt
{
    [Key]
    public int? ReceiptId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime IssueDate { get; set; }

    [Required]
    public decimal AmountReceived { get; set; }

    [DefaultValue(1)]
    public bool? IsActive { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [NotMapped]
    public ICollection<Product?>? Products { get; init; }
}