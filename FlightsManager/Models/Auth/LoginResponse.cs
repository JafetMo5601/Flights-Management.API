namespace FlightsManager.Models
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public string Role { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
