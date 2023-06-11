namespace cb2wled.Models
{
    public class UserDetail
    {
        public string Broadcaster { get; set; } = string.Empty;
        public User User { get; set; } = new();
    }
}