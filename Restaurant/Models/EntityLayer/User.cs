using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Restaurant.Model.EntityLayer.Enums;

namespace Restaurant.Model.EntityLayer;

public sealed class User
{
    [Key]
    public int? UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string? Username { get; set; }

    [Required]
    [MinLength(8), MaxLength(50)]
    public string? Password { get; set; }

    [Required]
    public EUserType UserType { get; set; }

    [DefaultValue(1)]
    public bool? IsActive { get; set; }

    public ICollection<Receipt?>? Receipts { get; init; }
}