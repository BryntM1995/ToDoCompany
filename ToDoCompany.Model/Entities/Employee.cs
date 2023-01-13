using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCompany.Model.Entities
{
    public class Employee : BaseEntity
    {

        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeAge { get; set; }
        public virtual ICollection<EmployeeTask> Tasks { get; set; }
        public Employee()
        {

        }
    }
}
