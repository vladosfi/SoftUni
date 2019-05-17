using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(Calculator claculator)
        {
            return View(claculator);
        }

        [HttpPost]
        public IActionResult Calculate(Calculator calculator)
        {   
            calculator.CalculateResult();
            
            return RedirectToAction("Index", calculator);
        }
    }
}
