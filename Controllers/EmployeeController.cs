using Microsoft.AspNetCore.Mvc;
using ManagementPortal.Models;

namespace ManagementPortal.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Salary()
        {
            ViewBag.Salary = 0;
            ViewBag.Name = "No Employee Selected";
            ViewBag.EmpTitle = "No Employee Selected";
            return View();
        }

        [HttpPost]
        public IActionResult Salary(Employee model)
        {
            ViewBag.Salary = model.CalculatePay();
            
            if (!String.IsNullOrEmpty(model.Name) || !String.IsNullOrEmpty(model.Title))
            {
                ViewBag.Name = model.Name;
                ViewBag.EmpTitle = model.Title;
            }
            else
            {
                ViewBag.Name = "No Employee Selected";
                ViewBag.EmpTitle = "No Employee Selected";
            }
            return View(model);
        }
    }
}
