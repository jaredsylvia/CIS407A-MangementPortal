using Microsoft.EntityFrameworkCore;
using ManagementPortal.Models;
namespace ManagementPortal.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = "AD", DepartmentName = "Administration" },
               new Department { DepartmentId = "AC", DepartmentName = "Accounting" },
               new Department { DepartmentId = "IT", DepartmentName = "Information Technology" },
               new Department { DepartmentId = "CS", DepartmentName = "Customer Service" },
               new Department { DepartmentId = "SA", DepartmentName = "Sales" },
               new Department { DepartmentId = "OP", DepartmentName = "Operations" }
               );

            //_ = modelBuilder.Ignore<Department>();     .OwnsOne(e => e.Department)
            
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Luke Skywalker",
                    StartDate = new DateTime(2010, 6, 15),
                    Title = "Human Resources Manager",
                    PayRate = 30,
                    Hours = "25:15",
                    DepartmentId = "AD"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Leia Organa",
                    StartDate = new DateTime(2007, 12, 17),
                    Title = "Junior Accountant",
                    PayRate = 18,
                    Hours = "40",
                    DepartmentId = "AC"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Ezra Bridger",
                    StartDate = new DateTime(2018, 9, 20),
                    Title = "Sales Associate",
                    PayRate = 22,
                    Hours = "45:35",
                    DepartmentId = "SA"
                }
                );
            
        }
    }
}
