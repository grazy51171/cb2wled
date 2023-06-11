namespace cb2wled.Models
{
    public class BroadcastDetail
    {
        public string Broadcaster { get; set; } = string.Empty;
        public User User { get; set; } = new();
    }

}