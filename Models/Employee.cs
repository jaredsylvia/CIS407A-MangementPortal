//TODO:
// *Add minimum wage somewhere, maybe another class for tax information could store minimum wage?
// *Hours is string of HH:MM. Could create work day object containing DateTime objects for start and end times and employee id
// *Implement employee id method. Semi-random, non-repeating, IMO ID is memorized bye mployee.
//      *Make pattern recognizeable: YY****, if **** is four hex digits allows for 65,536 employees for each year an employee was hired.
//      *I think this pattern is easy for employee to remember, ex. 230F8A
// *PTO and other accruable benefits. Is FMLA HIPAA?


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementPortal.Models
{
    public class Employee
    {
        //attributes
        private int id;
        private string name;
        private DateTime startDate;
        private string title;
        private decimal payRate;
        private TimeSpan hours;
        private string deptId;
        private Department department;
        


        //constructors
        public Employee()
        {
            id = 0;
            name = "John Doe";
            startDate = DateTime.Now;
            title = "Junior Employee";
            payRate = 15.00m;
            hours = new TimeSpan(40, 0, 0);
            deptId = "00";
            department = new Department();

        }

        public Employee(int id, string name, DateTime startDate, string title, decimal payRate, string hours, string deptId, Department department)
        {
            this.id = id;
            this.name = name;
            this.startDate = startDate;
            this.title = title;
            this.payRate = payRate;
            this.hours = CalculateHours(hours);
            this.deptId = deptId;
            this.department = department;
        }

        //behaviors

        public TimeSpan CalculateHours(dynamic hours)
        {
            try
            {
                if (hours is string)
                {
                    if (hours.Contains(":"))
                    {
                        Hours = TimeSpan.Parse(hours);
                    }
                    else
                    {
                        Hours = TimeSpan.FromHours(double.Parse(hours));
                    }
                }
                else if (hours is float)
                {
                    Hours = TimeSpan.FromHours(hours);
                }
                else
                {
                    throw new ArgumentException("Invalid input type. Hours must be a string or a float.");
                }

                return Hours;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid time format. Time must be in the format hh:mm.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error setting hours.", ex);
            }
        }

        public decimal CalculatePay()
        {
            return PayRate * (decimal)this.hours.TotalHours;
        }



        public override string ToString()
        {
            return String.Format("Id: {0}\nName: {1}\nStartDate: {2}\nTitle: {3}\nPayRate: {4}\n Hours: {5}",
                id, name, startDate, title, payRate, hours);
        }




        //getters and setters
        [Key]
        public int Id { get { return id; } set { id = value; } }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get { return name; } set { name = value; } }

        [Required(ErrorMessage = "Please enter the Start Date.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Start Date must be after 1/1/1900.")]
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        
        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(30, ErrorMessage = "Title must be 30 characters or less.")]
        public string Title { get { return title; } set { title = value; } }

        [Required(ErrorMessage = "Please enter a Pay Rate.")]
        [DataType(DataType.Currency)]
        [Range(0, 100, ErrorMessage = "Please enter the Pay Rate between 0 and 100")]
        public decimal PayRate { get { return payRate; } set { payRate = value; } }

        [Required(ErrorMessage = "Hours worked is required.")]
        [NotMapped]
        public TimeSpan Hours { 
            get { return hours; } 
            set { hours = value; }
        }

        [NotMapped]
        public string HoursString => $"{Hours.TotalHours + (Hours.Days * 24):00}:{Hours.Minutes:00}";

        public long MillisWorked
        {
            get { return (long)Hours.TotalMilliseconds; }
            set { Hours = TimeSpan.FromMilliseconds(value); }
        }

        [Required(ErrorMessage = "Please enter the Department.")]
        [ForeignKey("Department")]
        public string DepartmentId { get { return deptId; } set { deptId = value; } }  //foreign key
        [NotMapped]
        public Department Department { get { return department; } set { department = value; } } // Department object
    }
}
