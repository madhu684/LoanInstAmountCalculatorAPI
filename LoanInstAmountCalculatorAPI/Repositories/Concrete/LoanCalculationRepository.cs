using LoanInstAmountCalculatorAPI.AppServices;
using LoanInstAmountCalculatorAPI.DbContexts;
using LoanInstAmountCalculatorAPI.Entities;
using LoanInstAmountCalculatorAPI.Models;
using LoanInstAmountCalculatorAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LoanInstAmountCalculatorAPI.Repositories.Concrete
{
    public class LoanCalculationRepository : ILoanCalculationRepository
    {
        private readonly FinanceDbContext _financeDbContext;

        public LoanCalculationRepository(FinanceDbContext financeDbContext)
        {
            _financeDbContext = financeDbContext;
        }
        public LoanCalculationRepository()
        {

        }

        public double CreateLoanMonthlyAmount(LoanParameterDto parameterDto)
        {
            LoanCalculationApplicationService loanCalculationAppService = new LoanCalculationApplicationService();
            double amount = loanCalculationAppService.LoanMonthPaymentCalculation(parameterDto);
            return amount;
        }

        public IEnumerable<CalculationType> GetCalculationTypes()
        {
            var calculationTypes = this._financeDbContext.CalculationTypes
                                 .ToList();
            return calculationTypes;
        }
    }
}
