using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCompany.Service.DTOs
{
    public class EmployeeDto : BaseDto
    {
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeAge { get; set; }
    }
}
