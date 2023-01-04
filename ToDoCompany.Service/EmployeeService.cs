using AutoMapper;
using FluentValidation;
using System.Linq;
using ToDoCompany.Core;
using ToDoCompany.Model.Entities;
using ToDoCompany.Repository;
using ToDoCompany.Service.DTOs;
using ToDoCompany.Service.FluentValidation;

namespace ToDoCompany.Service
{
    public interface IEmployeeService : IBaseService<EmployeeDto> { }
    public class EmployeeService : BaseService<Employee, EmployeeDto> , IEmployeeService
    {
        public EmployeeService(IBaseRepository<Employee> _repository, IMapper mapper, AbstractValidator<EmployeeDto> validator) : base(_repository, mapper, validator)
        {
        }
    }
}
