using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.LoanServices
{
    public interface ILoanFinder
    {
        Quote GetLowestRateQuote(int requestedAmount);
    }
}
