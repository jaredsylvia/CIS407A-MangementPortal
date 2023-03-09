using ManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ManagementPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Salary(string empName, string empTitle, int weeklyHours, int empHourly)
        {
            ViewData["Title"] = "Salary Calculator";
            ViewData["Message"] = String.Format("Salary calculator for {0}, {1}:", empTitle, empName);
            ViewData["Hours"] = weeklyHours;
            ViewData["PayRate"] = empHourly;
            ViewData["Name"] = empName;
            ViewData["EmployeeTitle"] = empTitle;
            return View();
        }
                
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}