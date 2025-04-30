using System;
using System.Collections.Generic;
using Restaurant.Models.EntityLayer.Enums;

namespace Restaurant.Models.EntityLayer;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? DeliveryAddress { get; set; }

    public string Password { get; set; } = null!;

    public EUserType UserType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
