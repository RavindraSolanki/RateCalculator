using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.LoanServices.Utils
{
    public static class LoadLenders
    {
        public static IEnumerable<Lender> GetFromCsvFile(string csvFilePath)
        {
            var lenders = from line in File.ReadAllLines(csvFilePath).Skip(1)
                let columns = line.Split(',')
                select new Lender
                {
                    Name = columns[0],
                    Rate = decimal.Parse(columns[1]),
                    AvailableAmount = decimal.Parse(columns[2])
                };

            return lenders;
        }
    }
}
