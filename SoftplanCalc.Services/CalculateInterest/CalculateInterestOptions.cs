using System;
namespace SoftplanCalc.Services.CalculateInterest
{
    /// <summary>
    /// Calculate interest options.
    /// </summary>
    public class CalculateInterestOptions
    {
        /// <summary>
        /// Gets or sets the interest rate.
        /// </summary>
        /// <value>The interest rate.</value>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:SoftplanCalc.Services.CalculateInterest.CalculateInterestOptions"/> class.
        /// </summary>
        public CalculateInterestOptions()
        {
        }
    }
}
