using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftplanCalc.Logger;
using SoftplanCalc.Models;
using SoftplanCalc.Services.CalculateInterest;
using SoftplanCalc.Utils.Assert;

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
        /// The logger.
        /// </summary>
        private readonly IBaseLogger _logger;

        /// <summary>
        /// The calculate interest service.
        /// </summary>
        private readonly ICalculateInterestService _calculateInterestService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Controllers.CalculateInterestController"/> class.
        /// </summary>
        /// <param name="calculateInterestService">Calculate interest service.</param>
        public CalculateInterestController(IBaseLogger logger, ICalculateInterestService calculateInterestService)
        {
            _logger = logger;
            _calculateInterestService = calculateInterestService;
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet()]
        public ActionResult Get([FromQuery] CalculateInterestInput input)
        {
            try
            {
                AssertionConcern.AssertArgumentNotNull(input, "The Calculate Interest Input cannot be null.");
                AssertionConcern.AssertArgumentNotNull(input.ValorInicial, "The Valor Inicial cannot be null.");
                AssertionConcern.AssertArgumentNotNull(input.Meses, "The Meses cannot be null.");

                var result = _calculateInterestService.Calculate(input);
                _logger.Log($"Result calculated: {result}", LogEvent.Debug);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.Log(ex, LogEvent.Fatal);
                return BadRequest(ex);
            }
        }
    }
}
