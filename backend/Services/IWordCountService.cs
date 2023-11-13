using System.Threading.Tasks;
using backend.Data;

namespace backend.Services
{
    public interface IWordCountService
	{
        /// <summary>
        /// Gets the word count of specified topic in Wikipedia article.
        /// </summary>
        /// <param name="topic">Topic of the Wikipedia article.</param>
        /// <returns>The word count of specified topin in Wikipedia article.</returns>
        Task<WordCountData> GetWordCount(string topic);
    }
}

