using LoanInstAmountCalculatorAPI.Models;

namespace LoanInstAmountCalculatorAPI.AppServices
{
    public class LoanCalculationApplicationService
    {
        public double LoanMonthPaymentCalculation(LoanParameterDto parameterDto)
        {
            //Monthly loan installement calculation for Equal monthly installment
            if (parameterDto.CalculationType == 1)
            {
                double perInterestRate = parameterDto.InterestRate / 100;
                double val1 = perInterestRate + 1;
                double val2 = Math.Round(Math.Pow(val1, parameterDto.NoOfPayment), 3);
                double val3 = Math.Round((perInterestRate * val2),6);
                double val4 = val2 - 1;
                double val5 = Math.Round((val3 / val4),5);
                double amount = RoundUp((parameterDto.Principle * val5), 2);
                return amount;
            }
            return 0;
        }

        public static double RoundUp(double input, int decimalPlaces)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(decimalPlaces));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
    }
}
