
using LoanInstAmountCalculatorAPI.Entities;
using LoanInstAmountCalculatorAPI.Models;

namespace LoanInstAmountCalculatorAPI.Repositories.Abstract
{
    public interface ILoanCalculationRepository
    {
        IEnumerable<CalculationType> GetCalculationTypes();
        double CreateLoanMonthlyAmount(LoanParameterDto parameterDto);
    }
}
