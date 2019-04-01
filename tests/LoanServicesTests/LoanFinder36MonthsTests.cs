using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RateCalculator.LoanServices;

namespace RateCalculator.Tests.LoanServicesTests
{
    public class LoanFinder36MonthsTests
    {
        [Fact]
        public void When3LendersWithAvailableFund_ShouldGetQuoteFromLowestRateLender()
        {
            var lenders = new Lender[]
            {
                new Lender { Name = "lender1", AvailableAmount = 30000, Rate = 0.0345M },
                new Lender { Name = "lender2", AvailableAmount = 30000, Rate = 0.04M },
                new Lender { Name = "lender3", AvailableAmount = 30000, Rate = 0.0291M }
            };

            var sut = new LoanFinder36Months(lenders);
            var quote = sut.GetLowestRateQuote(10000);

            Assert.Equal(0.0291M, quote.OfferedRate);
        }

        [Fact]
        public void WhenNoLenderWithAvailableFund_ShouldGetNullQuote()
        {
            var lenders = new Lender[]
            {
                new Lender { Name = "lender1", AvailableAmount = 5000, Rate = 0.0345M },
                new Lender { Name = "lender2", AvailableAmount = 9000, Rate = 0.04M },
                new Lender { Name = "lender3", AvailableAmount = 12000, Rate = 0.0291M }
            };

            var sut = new LoanFinder36Months(lenders);
            var quote = sut.GetLowestRateQuote(14000);

            Assert.Null(quote);
        }
    }
}
