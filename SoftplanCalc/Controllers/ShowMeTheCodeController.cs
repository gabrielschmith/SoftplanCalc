using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftplanCalc.Api.Controllers
{
    /// <summary>
    /// Show me the code controller.
    /// </summary>
    [Route("/showmethecode")]
    public class ShowMeTheCodeController : Controller
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Controllers.ShowMetheCodeController"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public ShowMeTheCodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_configuration.GetValue<string>("Github"));
        }
    }
}
