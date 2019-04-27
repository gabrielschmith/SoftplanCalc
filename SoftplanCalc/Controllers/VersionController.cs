using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftplanCalc.Api.Controllers
{
    /// <summary>
    /// Version controller.
    /// </summary>
    [Route("[controller]")]
    public class VersionController : Controller
    {
        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok($"Version Api: {GetType().Assembly.GetName().Version}");
        }
    }
}
