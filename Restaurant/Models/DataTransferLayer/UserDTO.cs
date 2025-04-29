namespace Restaurant.Model.DataTransferLayer;

public class UserDTO
{
    public int? Id { get; init; }
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? UserType { get; init; }
}