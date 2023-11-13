using System.Text.Json.Serialization;

namespace backend.Data
{
	public sealed class WikiTextData
	{
        [JsonPropertyName("*")]
        public string Content { get; set; }
    }
}

