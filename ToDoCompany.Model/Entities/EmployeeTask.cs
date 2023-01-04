using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoCompany.Model.Entities
{
    public class EmployeeTask : BaseEntity
    {
        
        public string TaskName { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeIdInTask { get; set; }
        public virtual Employee Employee { get; set; }
        public string TaskDescription { get; set; }
        public EmployeeTask()
        {

        }
    }
}
