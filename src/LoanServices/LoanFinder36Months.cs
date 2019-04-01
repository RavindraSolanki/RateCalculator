using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.LoanServices
{
    public class LoanFinder36Months : ILoanFinder
    {
        private IEnumerable<Lender> _lenders;
        public LoanFinder36Months(IEnumerable<Lender> lenders)
        {
            _lenders = lenders;
        }

        public Quote GetLowestRateQuote(int requestedAmount)
        {
            throw new NotImplementedException();
        }
    }
}
