using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftplanCalc.Models;
using SoftplanCalc.Services.CalculateInterest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftplanCalc.Api.Controllers
{
    /// <summary>
    /// Calculate interest controller.
    /// </summary>
    [Route("/calculajuros")]
    public class CalculateInterestController : Controller
    {
        /// <summary>
        /// The calculate interest service.
        /// </summary>
        private readonly ICalculateInterestService _calculateInterestService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Controllers.CalculateInterestController"/> class.
        /// </summary>
        /// <param name="calculateInterestService">Calculate interest service.</param>
        public CalculateInterestController(ICalculateInterestService calculateInterestService)
        {
            _calculateInterestService = calculateInterestService;
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet()]
        public ActionResult Get([FromQuery] CalculateInterestInput input)
        {
            return Ok(_calculateInterestService.Calculate(input));
        }
    }
}
