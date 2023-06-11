namespace cb2wled.Models
{
    public class Tip
    {
        public int Tokens { get; set; }
        public bool IsAnon { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}