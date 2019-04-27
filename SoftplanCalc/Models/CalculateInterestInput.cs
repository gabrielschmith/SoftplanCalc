using System;
namespace SoftplanCalc.Api.Models
{
    public class CalculateInterestInput
    {
        public decimal InitialValue { get; set; }

        public decimal InterestRate { get; set; }

        public int Month { get; set; }

        public CalculateInterestInput()
        {
        }
    }
}
