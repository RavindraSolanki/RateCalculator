using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.LoanServices.Utils
{
    public static class RepaymentCalculator
    {
        public static RepaymentInfo GetRepayment(int borrowedAmount, decimal rate, int durationInMonths)
        {
            var monthlyRate = (double)rate / 12;
            var negativeNumberOfMonths = 0 - durationInMonths;
            var monthlyRepayment = borrowedAmount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, negativeNumberOfMonths));

            return new RepaymentInfo(
                borrowedAmount,
                rate, 
                Math.Round((decimal)monthlyRepayment, 2),
                Math.Round((decimal)monthlyRepayment * durationInMonths, 2));
        }
    }
}
