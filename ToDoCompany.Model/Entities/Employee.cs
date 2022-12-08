using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCompany.Model.Entities
{
    internal class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeAge { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public Employee()
        {

        }
    }
}
