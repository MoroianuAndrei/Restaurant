namespace Restaurant.Models.DataTransferLayer
{

    public class UserDTO
    {
        public int Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public string? Phone { get; init; }
        public string? DeliveryAddress { get; init; }
        public string? Password { get; init; }
        public string? UserType { get; init; }
    }
}