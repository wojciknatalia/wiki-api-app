using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace backend.Providers
{
    public class DataProvider : IDataProvider
    {
        #region Fields
        private readonly IHttpClientFactory _factory;
        #endregion

        #region Constructors
        public DataProvider(IHttpClientFactory factory)
		{
            _factory = factory;
		}
        #endregion

        #region Methods
        public Task<HttpResponseMessage> GetData(string url)
        {
            HttpClient client = _factory.CreateClient(nameof(DataProvider));
            Uri fullUri = new Uri(client.BaseAddress, url);
            return client.GetAsync(fullUri);
        }
        #endregion
    }
}

