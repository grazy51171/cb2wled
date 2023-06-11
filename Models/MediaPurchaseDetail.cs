namespace cb2wled.Models
{
    public class MediaPurchaseDetail
    {
        public string Broadcaster { get; set; } = string.Empty;
        public Media Media { get; set; } = new();
        public User User { get; set; } = new();
    }
}