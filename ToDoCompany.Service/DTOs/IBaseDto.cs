using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCompany.Service.DTOs
{
    public interface IBaseDto
    {
        public int Id { get; set; }
    }
    public class BaseDto : IBaseDto
    {
        public int Id { get; set; }
    }
}
