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
        private string hours;
        private string deptId;
        private Department department;


        //constructors
        public Employee()
        {
            id = 1;
            name = "John Doe";
            startDate = DateTime.Now;
            title = "Junior Employee";
            payRate = 15.00m; 
            hours = "40:00";
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
            if (hours.Contains('.')) //RegEx comparison should replace this, is used in setter also - should be refactored
            {
                float hoursFloat = float.Parse(hours, System.Globalization.CultureInfo.InvariantCulture);
                TimeSpan hTimeSpan = TimeSpan.FromHours(hoursFloat);
                this.hours = hTimeSpan.ToString("hh':'mm");
            } else
            {
                this.hours = hours;
            }
            this.deptId = deptId;
            this.department = department;
        }

        //behaviors

        public decimal CalculatePay()
        {
            string[] h;
            decimal decHours; //decHours should be refactored and return a decimal of hours worked.
            try
            {
                h = this.hours.Split(new string[] { ":" }, StringSplitOptions.None);
                
            }
            catch (NullReferenceException)
            {
                h = new string[] { "0", "0" }; 
            }
            try
            {
                decHours = Math.Round(Convert.ToDecimal(h[0]) + (Convert.ToDecimal(h[1]) / 60), 2);
                
            }
            catch (IndexOutOfRangeException)
            {
                decHours = Math.Round(Convert.ToDecimal(h[0]));
                
            }
            return this.payRate * decHours;
        }

        public override string ToString()
        {
            return String.Format("Id: {0}\nName: {1}\nStartDate: {2}\nTitle: {3}\nPayRate: {4}\n Hours: {5}",
                id, name, startDate, title, payRate, hours);
        }




        //getters and setters
        [Key]
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public string Title { get { return title; } set { title = value; } }
        public decimal PayRate { get { return payRate; } set { payRate = value; } }
        public string Hours { 
            get { return hours; } 
            set
            { //RegEx comparison should replace this, is used in constructor also - should be refactored
                if (value.Contains('.'))
                {
                    float hoursFloat = float.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
                    TimeSpan hTimeSpan = TimeSpan.FromHours(hoursFloat);
                    hours = hTimeSpan.ToString("hh':'mm");
                }
                else
                {
                    hours = value;
                }
            } 
        }

        [ForeignKey("Department")]
        public string DepartmentId { get { return deptId; } set { deptId = value; } }  //foreign key
        [NotMapped]
        public Department Department { get { return department; } set { department = value; } } // Department object
    }
}
