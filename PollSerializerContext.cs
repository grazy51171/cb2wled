using cb2wled.Models;
using System.Text.Json.Serialization;

namespace cb2wled
{
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(PollResponse))]
    [JsonSerializable(typeof(Event))]
    public partial class PollSerializerContext : JsonSerializerContext
    {
    }
}
