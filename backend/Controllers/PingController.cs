using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : Controller
    {
        #region Methods
        /// <summary>
        /// Healthcheck to make sure the service is up.
        /// </summary>
        /// <returns>Healthcheck result.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("The service is up and running.");
        }
        #endregion
    }
}
