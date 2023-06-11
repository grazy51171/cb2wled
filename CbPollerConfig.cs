public class CbPollerConfig
{
    public required Uri PollingUri { get; set; } 
    public int Timeout { get; set; } = 20;
}