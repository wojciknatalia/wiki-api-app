using System.Threading.Tasks;
using backend.Data;

namespace backend.Services
{
    public interface IWikiDataService
	{
        /// <summary>
        /// Gets the response of Wikipedia API for specified topic.
        /// </summary>
        /// <param name="topic">Topic of the Wikipedia article.</param>
        /// <returns>The response of Wikipedia API for specified topic.</returns>
        Task<WikiApiResponse> GetData(string topic);
    }
}

