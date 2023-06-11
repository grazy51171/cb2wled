namespace cb2wled.Models
{
    public class MessageDetail
    {

        public string Color { get; set; } = string.Empty;
        public string BgColor { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Font { get; set; } = string.Empty;

        public string FromUser { get; set; } = string.Empty;
        public string ToUser { get; set; } = string.Empty;
    }
}