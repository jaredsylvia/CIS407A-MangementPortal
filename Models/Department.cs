using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementPortal.Models
{
    public class Department
    {
        private string deptId;
        private string deptName;
        private ICollection<Employee> emps;
        
        public Department()
        {
            deptId = "00";
            deptName = "No Deparment Set";
            this.emps = new HashSet<Employee>();

        }

        public Department(string deptId, string deptName, ICollection<Employee> emps)
        {
            this.deptId = deptId;
            this.deptName = deptName;
            this.emps = emps;
        }

        public string DepartmentId { get { return deptId; } set { deptId = value; } }
        public string DepartmentName { get { return deptName; } set { deptName = value; } }

        public ICollection<Employee> Employees { get { return emps; } set { emps = value; } }
        
    }
}