using System;
using SoftplanCalc.Models;

namespace SoftplanCalc.Services.CalculateInterest
{
    /// <summary>
    /// Calculate interest service.
    /// </summary>
    public interface ICalculateInterestService
    {
        /// <summary>
        /// Calculate the specified input.
        /// </summary>
        /// <returns>The calculate.</returns>
        /// <param name="input">Input.</param>
        decimal Calculate(CalculateInterestInput input);
    }
}
