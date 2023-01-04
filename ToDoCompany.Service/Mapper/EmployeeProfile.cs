using AutoMapper;
using ToDoCompany.Model.Entities;
using ToDoCompany.Service.DTOs;

namespace ToDoCompany.Service.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
