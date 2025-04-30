using System;
using System.Collections.Generic;

namespace Restaurant.Models.EntityLayer;

public partial class AppSetting
{
    public string SettingKey { get; set; } = null!;

    public string SettingValue { get; set; } = null!;

    public string? Description { get; set; }
}
