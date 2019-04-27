using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftplanCalc.Api.Controllers
{
    /// <summary>
    /// Show me the code controller.
    /// </summary>
    [Route("/showmethecode")]
    public class ShowMetheCodeController : Controller
    {
        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("https://github.com/gabrielschmith/SoftplanCalc");
        }
    }
}
