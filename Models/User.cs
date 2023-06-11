namespace cb2wled.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public bool InFanclub { get; set; }
        public string Gender { get; set; } = string.Empty;
        public bool HasTokens { get; set; }
        public string RecentTips { get; set; } = string.Empty;
        public bool IsMod { get; set; }
    }
}