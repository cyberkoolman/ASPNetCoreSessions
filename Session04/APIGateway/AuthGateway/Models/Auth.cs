namespace Gateway.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class AuthUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }    
}
