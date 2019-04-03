using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace RateCalculator.Tests.ConsoleAppTests
{
    public class ProgramTests
    {
        private const string Test1LenderCsvFile = ".\\TestLenderCsvFiles\\Test1.csv";
        private const int TestAmount = 10000;

        private int _lastExitCode;
        private string _consoleOutput;

        private void RunConsoleApp(string csvFilePath, int amount)
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                _lastExitCode = ConsoleApp.Program.Main(new[] { csvFilePath, amount.ToString() });
                _consoleOutput = writer.ToString();
            }
        }

        [Fact]
        public void WhenLenderCsvFileIsNotFound_ShouldExitWithError()
        {
            RunConsoleApp("NonExistingLenderFile.csv", TestAmount);
            Assert.NotEqual(0, _lastExitCode);
        }

        [Theory]
        [InlineData(999)]
        [InlineData(15001)]
        public void WhenAmountIsLessThan1000OrMoreThan15000_ShouldExitWithError(int invalidAmount)
        {
            RunConsoleApp(Test1LenderCsvFile, invalidAmount);
            Assert.NotEqual(0, _lastExitCode);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(15000)]
        public void WhenAmountIsBetween1000And15000_ShouldExitWithoutError(int validAmount)
        {
            RunConsoleApp(Test1LenderCsvFile, validAmount);
            Assert.Equal(0, _lastExitCode);
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(1099)]
        [InlineData(14901)]
        [InlineData(14999)]
        public void WhenAmountIsNotAnIncrementOf100_ShouldExitWithError(int invalidAmount)
        {
            RunConsoleApp(Test1LenderCsvFile, invalidAmount);
            Assert.NotEqual(0, _lastExitCode);
        }

        [Fact]
        public void WhenNoOfferIsAvailable_ShouldDisplayAnInfoMessage()
        {
            RunConsoleApp(Test1LenderCsvFile, 15000);

            var match = Regex.Match(_consoleOutput, "It is not possible to provide aquote at this time\\.");
            Assert.True(match.Success);
        }

        [Fact]
        public void WhenAnOfferIsAvailable_ShouldDisplayTheRequestedAmount()
        {
            RunConsoleApp(Test1LenderCsvFile, TestAmount);

            var match = Regex.Match(_consoleOutput, "Requested amount: £([0-9]+)");
            Assert.True(match.Success);
        }

        [Fact]
        public void WhenAnOfferIsAvailable_ShouldDisplayRateWithOneDecimal()
        {
            RunConsoleApp(Test1LenderCsvFile, TestAmount);

            var match = Regex.Match(_consoleOutput, "Rate: ([0-9]+\\.[0-9]{1})%");
            Assert.True(match.Success);
        }

        [Fact]
        public void WhenAnOfferIsAvailable_ShouldDisplayMonthlyRepaymentWithTwoDecimal()
        {
            RunConsoleApp(Test1LenderCsvFile, TestAmount);

            var match = Regex.Match(_consoleOutput, "Monthly repayment: £([0-9]+\\.[0-9]{2})");
            Assert.True(match.Success);
        }

        [Fact]
        public void WhenAnOfferIsAvailable_ShouldDisplayTotalRepaymentWithTwoDecimal()
        {
            RunConsoleApp(Test1LenderCsvFile, TestAmount);

            var match = Regex.Match(_consoleOutput, "Total repayment: £([0-9]+\\.[0-9]{2})");
            Assert.True(match.Success);
        }
    }
}
