using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RateCalculator.Tests.LoanServicesTests.Utils
{
    public class RepaymentCalculatorTests
    {
        [Theory]
        [InlineData(10000, .031, 36, 291.25, 10485.11)]
        [InlineData(15000, .045, 36, 446.20, 16063.34)]
        [InlineData(15000, .027, 24, 642.73, 15425.51)]
        public void WithGivenAmountRateAndDuration_ReturnCorrectMonthlyAndTotalRepayment(
            int borrowedAmount, 
            decimal rate, 
            int durationInMonths,
            decimal expectedMonthlyRepayment, 
            decimal expectedTotalRepayment)
        {
            var repayment = LoanServices.Utils.RepaymentCalculator.GetRepayment(borrowedAmount, rate, durationInMonths);

            Assert.Equal(expectedMonthlyRepayment, repayment.MonthlyRepaymentAmount);
            Assert.Equal(expectedTotalRepayment, repayment.TotalRepaymentAmount);
        }
    }
}
