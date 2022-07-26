using LoanInstAmountCalculatorAPI.Controllers;
using LoanInstAmountCalculatorAPI.Models;
using LoanInstAmountCalculatorAPI.Repositories.Abstract;
using LoanInstAmountCalculatorAPI.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace LoanCalculatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateLoanMonthAmount()
        {
            var loanCalculationRepository = new LoanCalculationRepository();
            LoanParameterDto loan = new LoanParameterDto();
            loan.CalculationType = 1;
            loan.Principle = 3500;
            loan.InterestRate = 0.67;
            loan.NoOfPayment = 36;

            LoanCalculationController home = new LoanCalculationController(null, loanCalculationRepository);
            IActionResult result = home.CreateLoanMonthlyAmount(loan);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(109.66, okResult.Value);
        }
    }
}