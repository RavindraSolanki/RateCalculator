using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.LoanServices
{
    public class Quote
    {
        public int RequestedAmount { get; set; }
        public decimal OfferedRate { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalRepayment { get; set; }
        public Lender FromLender { get; set; }
    }
}
