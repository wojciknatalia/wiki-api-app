using System.Text.Json.Serialization;

namespace backend.Data
{
	public sealed class WikiApiResponse
	{
        [JsonPropertyName("parse")]
        public WikiData WikiData { get; set; }
    }
}

