using Microsoft.AspNetCore.Mvc;
using ManagementPortal.Models;
using ManagementPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagementPortal.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext context { get; set; }

        public EmployeeController(EmployeeContext ctx)
        {
            context = ctx;
        }
        /* public IActionResult Index()
        {
            var departments = context.Departments.ToList(); 
            foreach (var emp in context.Employees.ToList()) // This is the worst possible way to do this I think, but the emp objects don't seem to have the department objects they should
            {                                              // I think that there's probably something I can do in the context that sets that somewhere
                var dept = departments.Find(x => x.DepartmentId.Equals(emp.DepartmentId));
                emp.Department = dept; // Can be null here, should not be able to be null or deal with it later by catching an exception?
            }
            var employees = context.Employees.ToList();
            
            return View(employees);
        } */

        public IActionResult Index(string searchString)
        {
            var departments = context.Departments.ToList();
            foreach (var emp in context.Employees.ToList()) 
            {
                var dept = departments.Find(x => x.DepartmentId.Equals(emp.DepartmentId));
                emp.Department = dept;
            }

            var employees = from e in context.Employees select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
            }
            return View(employees.ToList());
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

        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
            return View("Edit", new Employee());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
            var employee = context.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    context.Employees.Add(employee);
                }
                else
                {
                    context.Employees.Update(employee);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();

                ViewBag.Action = (employee.Id == 0) ? "Add" : "Edit";
                return View(employee);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            ViewBag.Action = "Delete";
            var employee = context.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {

            ViewBag.Action = "Delete";
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employee");

        }
    }
}
