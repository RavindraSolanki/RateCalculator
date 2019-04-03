using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.ConsoleApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var csvFilePath = args[0];
            if (File.Exists(csvFilePath) == false)
            {
                Console.WriteLine($"File not found {csvFilePath}");
                return 1;
            }

            var requestedAmount = int.Parse(args[1]);
            if (requestedAmount < 1000 || requestedAmount > 15000)
            {
                Console.WriteLine($"Requested amount {csvFilePath} is invalid. Min amount is 10000 and max amount is 15000");
                return 1;
            }
            if (requestedAmount % 100 != 0)
            {
                Console.WriteLine($"Requested amount {csvFilePath} is invalid. Amount has to be an interval of 100 between 10000 and 15000");
                return 1;
            }

            var lenders = LoanServices.Utils.LoadLenders.GetFromCsvFile(csvFilePath);
            var loanFinder = new LoanServices.LoanFinder36Months(lenders);

            var quote = loanFinder.GetLowestRateQuote(requestedAmount);

            if (quote == null)
            {
                Console.WriteLine("It is not possible to provide aquote at this time.");
                return 0;
            }

            Console.WriteLine($"Requested amount: £{quote.RequestedAmount}");
            Console.WriteLine($"Rate: {(quote.OfferedRate * 100).ToString("0.0")}%");
            Console.WriteLine($"Monthly repayment: £{quote.MonthlyRepayment.ToString("0.00")}");
            Console.WriteLine($"Total repayment: £{quote.TotalRepayment.ToString("0.00")}");

            return 0;
        }
    }
}
