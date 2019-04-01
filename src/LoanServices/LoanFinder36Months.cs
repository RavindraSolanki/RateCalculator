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
            var lenderWithLowestRate = _lenders
                .Where(_ => _.AvailableAmount >= requestedAmount)
                .OrderBy(_ => _.Rate)
                .FirstOrDefault();

            if (lenderWithLowestRate == null)
            {
                return null;
            }

            var repayment = Utils.RepaymentCalculator.GetRepayment(requestedAmount, (decimal)lenderWithLowestRate.Rate, 36);

            return new Quote
            {
                FromLender = lenderWithLowestRate,
                OfferedRate = lenderWithLowestRate.Rate,
                RequestedAmount = requestedAmount,
                MonthlyRepayment = repayment.MonthlyRepaymentAmount,
                TotalRepayment = repayment.TotalRepaymentAmount
            };
        }
    }
}
