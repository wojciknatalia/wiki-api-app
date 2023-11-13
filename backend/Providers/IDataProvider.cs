using System.Net.Http;
using System.Threading.Tasks;

namespace backend.Providers
{
    public interface IDataProvider
	{
        /// <summary>
        /// Sends request to the specified url and retrieves the response.
        /// </summary>
        /// <param name="url">Url to send the request to.</param>
        /// <returns>The response as a HttpResponseMessage.</returns>
        public Task<HttpResponseMessage> GetData(string url);
	}
}

