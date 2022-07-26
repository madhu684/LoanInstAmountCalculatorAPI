using LoanInstAmountCalculatorAPI.Models;
using LoanInstAmountCalculatorAPI.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LoanInstAmountCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanCalculationController : Controller
    {
        private readonly ILogger<LoanCalculationController> _logger;
        private readonly ILoanCalculationRepository _ILoanCalculationRepository;
        public LoanCalculationController(ILogger<LoanCalculationController> logger, ILoanCalculationRepository loanCalculationRepository)
        {
            _logger = logger;
            _ILoanCalculationRepository = loanCalculationRepository;
        }

        [HttpGet]
        public IActionResult GetCalculationTypes()
        {
            try
            {
                _logger?.LogInformation("Request Processing...");
                var calculationTypes = this._ILoanCalculationRepository.GetCalculationTypes();

                if (calculationTypes == null)
                {
                    _logger?.LogInformation("Calculation types not found");
                    return NotFound();
                }
                else
                {
                    _logger?.LogInformation("Calculation types fetched successfully");
                    return Ok(calculationTypes);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError("Error while processing...", ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public  IActionResult CreateLoanMonthlyAmount([FromForm] LoanParameterDto loanParameterDto)
        {
            try
            {
                LoanParameterDto loan = new LoanParameterDto();
                loan.CalculationType = 1;
                loan.Principle = 3500;
                loan.InterestRate = 0.67;
                loan.NoOfPayment = 36;

                _logger?.LogInformation("Calculation Processing...");
                double amount = this._ILoanCalculationRepository.CreateLoanMonthlyAmount(loanParameterDto);

                _logger?.LogInformation("Request Processed...");
                return Ok(amount);
            }
            catch (Exception ex)
            {
                _logger?.LogError("Error while processing...", ex.ToString());
                return BadRequest();
            }
        }


    }
}
