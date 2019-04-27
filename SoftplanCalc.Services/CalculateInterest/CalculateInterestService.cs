using System;
using SoftplanCalc.Models;

namespace SoftplanCalc.Services.CalculateInterest
{
    /// <summary>
    /// Calculate interest service.
    /// </summary>
    public class CalculateInterestService : ICalculateInterestService
    {
        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        private CalculateInterestOptions _options { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:SoftplanCalc.Services.CalculateInterest.CalculateInterestService"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public CalculateInterestService(CalculateInterestOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// Calculate the specified input.
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="input">Input.</param>
        public decimal Calculate(CalculateInterestInput input)
        {
            var initialValue = Convert.ToDouble(input.ValorInicial);
            var interestRate = Convert.ToDouble(_options.InterestRate);
            var interestRateCalculed = Math.Pow(1 + interestRate, input.Meses);
            var result = initialValue * interestRateCalculed;
            var resultWithTruncate = Convert.ToDecimal(Math.Truncate(100 * result) / 100);

            return resultWithTruncate;
        }
    }
}
