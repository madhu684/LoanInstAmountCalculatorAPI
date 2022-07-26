using Microsoft.AspNetCore.Mvc;

namespace LoanInstAmountCalculatorAPI.Controllers
{
    public class LoanAmountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
