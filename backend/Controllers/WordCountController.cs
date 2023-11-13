using System.Threading.Tasks;
using backend.Data;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCountController : Controller
    {
        #region Properties
        private readonly IWordCountService _wordCountService;
        #endregion

        #region Constructors
        public WordCountController(IWordCountService wordCountService)
        {
            _wordCountService = wordCountService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculates the number of times a certain word appears in the fetched Wikipedia text.
        /// </summary>
        /// <param name="topic">The specified topic of Wikipedia article.</param>
        // <returns>the number of times a certain word appears in the fetched Wikipedia text for specified topic.</returns>
        [HttpGet("{topic}")]
        public async Task<IActionResult> GetCreditData(string topic)
        {
            WordCountData wordCount = await _wordCountService.GetWordCount(topic);
            return Ok(wordCount);
        }
        #endregion
    }
}

