namespace LoanInstAmountCalculatorAPI.Models
{
    public class LoanParameterDto
    {
        public int CalculationType { get; set; }
        public double Principle { get; set; }
        public double InterestRate { get; set; }
        public int NoOfPayment { get; set; }
    }
}
