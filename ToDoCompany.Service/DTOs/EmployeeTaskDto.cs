namespace ToDoCompany.Service.DTOs
{
    public class EmployeeTaskDto : BaseDto
    {
        public string TaskName { get; set; }
        public int EmployeeIdInTask { get; set; }
        public string TaskDescription { get; set; }
    }
}
