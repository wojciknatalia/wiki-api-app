using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Data;
using backend.Providers;

namespace backend.Services
{
    public sealed class WikiDataService : IWikiDataService
	{
        #region Fields
        private readonly IDataProvider _dataProvider;
        #endregion

        #region Constructors
        public WikiDataService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        #endregion

        #region Methods
        public async Task<WikiApiResponse> GetData(string topic)
        {
            string apiUrl = $"api.php?action=parse&section=0&prop=text&format=json&page={topic}";
            return await GetWikiData(apiUrl);
        }

        private async Task<WikiApiResponse> GetWikiData(string relativeUrl)
        {
            HttpResponseMessage response = await _dataProvider.GetData(relativeUrl);

            if (response == null || response.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }

            string result = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WikiApiResponse>(result);
        }
        #endregion
    }
}

