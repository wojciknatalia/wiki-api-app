using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Data;

namespace backend.Services
{
    public sealed class WordCountService : IWordCountService
    {
        #region Fields
        private readonly IWikiDataService _wikiDataService;
        #endregion

        #region Constructors
        public WordCountService(IWikiDataService wikiDataService)
        {
            _wikiDataService = wikiDataService;
        }
        #endregion

        #region Methods
        public async Task<WordCountData> GetWordCount(string topic)
        {
            Task<WikiApiResponse> wikiApiResponse = _wikiDataService.GetData(topic);
            WikiApiResponse apiData = await wikiApiResponse;

            return new WordCountData()
            {
                WordCount = apiData == null ? 0 : CountOccurrences(apiData.WikiData.Text.Content, topic)
            };
        }

        static int CountOccurrences(string source, string search)
        {
            // Use regex to match whole words
            string pattern = $@"\b{Regex.Escape(search)}\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Count occurrences
            int count = regex.Matches(source).Count;
            return count;
        }
        #endregion
    }
}

