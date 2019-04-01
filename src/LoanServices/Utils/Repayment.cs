using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.LoanServices.Utils
{
    public class Repayment
    {
        public Repayment(int borrowedAmount, 
            decimal rate, 
            decimal monthlyRepaymentAmount, 
            decimal totalRepaymentAmount)
        {
            BorrowedAmount = borrowedAmount;
            Rate = rate;
            MonthlyRepaymentAmount = monthlyRepaymentAmount;
            TotalRepaymentAmount = totalRepaymentAmount;
        }

        public int BorrowedAmount { get; }
        public decimal Rate { get; set; }
        public decimal MonthlyRepaymentAmount { get; }
        public decimal TotalRepaymentAmount { get; }
    }
}
