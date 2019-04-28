using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SoftplanCalc.Api.Controllers;
using SoftplanCalc.Logger;
using SoftplanCalc.Models;
using SoftplanCalc.Services.CalculateInterest;
using Xunit;

namespace SoftplanCalc.Api.Tests
{
    public class CalculateInterestControllerUnitTest
    {
        /// <summary>
        /// The show me the code controller.
        /// </summary>
        private readonly CalculateInterestController _calculateInterestController;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Tests.CalculateInterestControllerUnitTest"/> class.
        /// </summary>
        public CalculateInterestControllerUnitTest()
        {
            var configuration = TestHelper.GetIConfiguration(Directory.GetCurrentDirectory());

            var options = new CalculateInterestOptions();
            var section = configuration.GetSection("CalculateInterest");
            section.Bind(options);

            var calculateInsterestService = new CalculateInterestService(options);
            var logger = new BaseLogger();

            _calculateInterestController = new CalculateInterestController(logger, calculateInsterestService);
        }

        /// <summary>
        /// Shoulds the calculate interest controller.
        /// </summary>
        /// <param name="valorInicial">Valor inicial.</param>
        /// <param name="meses">Meses.</param>
        /// <param name="result">Result.</param>
        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(200, 10, 220.92)]
        [InlineData(450.98, 12, 508.17)]
        [InlineData(1000, 3, 1030.30)]
        [InlineData(25000, 24, 31743.36)]
        public void ShouldCalculateInterestController(decimal valorInicial, int meses, decimal result)
        {
            var input = new CalculateInterestInput
            {
                ValorInicial = valorInicial,
                Meses = meses
            };

            var actual = Assert.IsType<OkObjectResult>(_calculateInterestController.Get(input));
            var expected = result;

            Assert.Equal(expected, actual.Value);
        }
    }
}
