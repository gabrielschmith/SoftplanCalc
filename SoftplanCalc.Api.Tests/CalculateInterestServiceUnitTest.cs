using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftplanCalc.Models;
using SoftplanCalc.Services.CalculateInterest;
using Xunit;

namespace SoftplanCalc.Api.Tests
{
    /// <summary>
    /// Calculate interest service unit test.
    /// </summary>
    public class CalculateInterestServiceUnitTest
    {
        /// <summary>
        /// The calculate interest service with dependency injection.
        /// </summary>
        private readonly ICalculateInterestService _calculateInterestService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Tests.CalculateInterestServiceUnitTest"/> class.
        /// </summary>
        public CalculateInterestServiceUnitTest()
        {
            var configuration = TestHelper.GetIConfiguration(Directory.GetCurrentDirectory());

            var options = new CalculateInterestOptions();
            var section = configuration.GetSection("CalculateInterest");
            section.Bind(options);

            _calculateInterestService = new CalculateInterestService(options);
    }

        /// <summary>
        /// Shoulds the calculate zero when initial value is zero.
        /// </summary>
        [Fact]
        public void ShouldCalculateZeroWhenInitialValueIsZero()
        {
            var calculateInterestInput = new CalculateInterestInput
            {
                ValorInicial = 0,
                Meses = 1
            };

            var actual = _calculateInterestService.Calculate(calculateInterestInput);
            var expected = 0m;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shoulds the calculate zero when month is zero.
        /// </summary>
        [Fact]
        public void ShouldCalculateWhenMonthIsZero()
        {
            var calculateInterestInput = new CalculateInterestInput
            {
                ValorInicial = 100,
                Meses = 0
            };

            var actual = _calculateInterestService.Calculate(calculateInterestInput);
            var expected = 100m;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shoulds the calculate zero when initial value and month is zero.
        /// </summary>
        [Fact]
        public void ShouldCalculateZeroWhenInitialValueAndMonthIsZero()
        {
            var calculateInterestInput = new CalculateInterestInput
            {
                ValorInicial = 0,
                Meses = 0
            };

            var actual = _calculateInterestService.Calculate(calculateInterestInput);
            var expected = 0m;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shoulds the calculate zero when interest rate is zero.
        /// </summary>
        [Fact]
        public void ShouldCalculateWhenInterestRateIsZero()
        {
            var interestRate = 0m;
            var calculateInterestInput = new CalculateInterestInput
            {
                ValorInicial = 100,
                Meses = 5
            };

            var actual = _calculateInterestService.Calculate(calculateInterestInput, interestRate);
            var expected = 100m;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shoulds the calculate interest value from example.
        /// </summary>
        [Fact]
        public void ShouldCalculateInterestValueFromExample()
        {
            var calculateInterestInput = new CalculateInterestInput
            {
                ValorInicial = 100,
                Meses = 5
            };

            var actual = _calculateInterestService.Calculate(calculateInterestInput);
            var expected = 105.10m;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shoulds the calculate interest values with interest rate set in options.
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
        public void ShouldCalculateInterestValuesWithInterestRateSetInOptions(decimal valorInicial, int meses, decimal result)
        {
            var actual = _calculateInterestService.Calculate(new CalculateInterestInput
            {
                ValorInicial = valorInicial,
                Meses = meses
            });
            var expected = result;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shoulds the calculate interest values without interest rate set in options.
        /// </summary>
        /// <param name="valorInicial">Valor inicial.</param>
        /// <param name="meses">Meses.</param>
        /// <param name="interestRate">Interest rate.</param>
        /// <param name="result">Result.</param>
        [Theory]
        [InlineData(100, 5, .01, 105.10)]
        [InlineData(100, 5, .02, 110.40)]
        [InlineData(200, 10, .03, 268.78)]
        [InlineData(450.98, 12, .03, 642.98)]
        [InlineData(1000, 3, .05, 1157.62)]
        [InlineData(25000, 24, .02, 40210.93)]
        public void ShouldCalculateInterestValuesWithoutInterestRateSetInOptions(decimal valorInicial, int meses, decimal interestRate, decimal result)
        {
            var input = new CalculateInterestInput
            {
                ValorInicial = valorInicial,
                Meses = meses
            };

            var actual = _calculateInterestService.Calculate(input, interestRate);
            var expected = result;

            Assert.Equal(expected, actual);
        }
    }
}
