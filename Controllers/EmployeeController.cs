using Microsoft.AspNetCore.Mvc;
using ManagementPortal.Models;
using ManagementPortal.Data;


namespace ManagementPortal.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext context { get; set; }

        public EmployeeController(EmployeeContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var departments = context.Departments.ToList(); 
            foreach (var emp in context.Employees.ToList()) // This is the worst possible way to do this I think, but the emp objects don't seem to have the department objects they should
            {                                              // I think that there's probably something I can do in the context that sets that somewhere
                var dept = departments.Find(x => x.DepartmentId.Equals(emp.DepartmentId));
                emp.Department = dept; // Can be null here, should not be able to be null or deal with it later by catching an exception?
            }
            var employees = context.Employees.ToList();
            
            return View(employees);
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
