using System.Text.Json.Serialization;

namespace backend.Data
{
	public sealed class WordCountData
	{
        [JsonPropertyName("wordcount")]
        public int WordCount { get; set; }
    }
}

