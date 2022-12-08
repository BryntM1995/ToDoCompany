using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoCompany.Model.Entities
{
    internal class EmployeeTask
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeIdInTask { get; set; }
        public virtual Employee Employee { get; set; }
        public string TaskDescription { get; set; }
        public bool IsDeleted { get; set; }

        public EmployeeTask()
        {

        }
    }
}
