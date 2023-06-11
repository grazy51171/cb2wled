namespace cb2wled.Models
{
    public class ChatMessageDetail
    {
        public string Broadcaster { get; set; } = string.Empty;
        public MessageDetail message { get; set; } = new();
        public User User { get; set; } = new();
    }
}