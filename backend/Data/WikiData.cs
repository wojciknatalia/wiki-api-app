using System.Text.Json.Serialization;

namespace backend.Data
{
    public sealed class WikiData
	{
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public int PageId { get; set; }

        [JsonPropertyName("text")]
        public WikiTextData Text { get; set; }
    }
}

