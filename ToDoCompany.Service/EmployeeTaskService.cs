using AutoMapper;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ToDoCompany.Core;
using ToDoCompany.Model.Entities;
using ToDoCompany.Repository;
using ToDoCompany.Service.DTOs;
using ToDoCompany.Service.FluentValidation;

namespace ToDoCompany.Service 
{
    public interface IEmployeeTaskService : IBaseService<EmployeeTaskDto> { }
    public class EmployeeTaskService : BaseService<EmployeeTask,EmployeeTaskDto> , IEmployeeTaskService
    {
        public EmployeeTaskService(IBaseRepository<EmployeeTask> _repository, IMapper mapper, AbstractValidator<EmployeeTaskDto> validator) : base(_repository, mapper, validator)
        {

        }
    }
}
