using System;
namespace SoftplanCalc.Models
{
    /// <summary>
    /// Calculate interest input.
    /// </summary>
    public class CalculateInterestInput
    {
        /// <summary>
        /// Gets or sets the valor inicial.
        /// </summary>
        /// <value>The valor inicial.</value>
        public decimal ValorInicial { get; set; }

        /// <summary>
        /// Gets or sets the meses.
        /// </summary>
        /// <value>The meses.</value>
        public int Meses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Models.CalculateInterestInput"/> class.
        /// </summary>
        public CalculateInterestInput()
        {
        }
    }
}
