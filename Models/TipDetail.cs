namespace cb2wled.Models
{
    public class TipDetail
    {
        public string Broadcaster { get; set; } = string.Empty;
        public Tip Tip { get; set; } = new();
        public User User { get; set; } = new();
    }


}