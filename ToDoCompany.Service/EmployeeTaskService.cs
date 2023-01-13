using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
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
        public EmployeeTaskService(IBaseRepository<EmployeeTask> _repository, IMapper mapper, IValidator<EmployeeTaskDto> validator) : base(_repository, mapper, validator)
        {
        }
        private readonly IValidator<EmployeeTaskDto> _validator;
        private readonly IMapper _mapper;
        public IOperationResult AddEmployeeTask(EmployeeTaskDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                return new OperationResult
                {
                    Messages = result.Errors.Select(x => x.ErrorMessage)
                };
            }

            if (_repository.GetAll().Where(x => x.Id == dto.Id).Any())
            {
                return new OperationResult
                {
                    Messages = new List<string>
                    {
                        "This entity already exist."
                    }
                };
            }
            var entity = _mapper.Map<EmployeeTask>(dto);
            _repository.Add(entity);
            return new OperationResult();
        }
        public IEnumerable<EmployeeTaskDto> GetAllEmployeeTasks()
        {
            var entityDtos = _mapper.Map<IEnumerable<EmployeeTaskDto>>(_repository.GetAll());
            return entityDtos;
        }

        public EmployeeTaskDto GeteEmployeeTaskById(int key)
        {
            var entity = _repository.GetById(key);
            var dto = _mapper.Map<EmployeeTaskDto>(entity);
            return dto;
        }

        public IOperationResult RemoveeEmployeeTask(int key)
        {

            if (_repository.GetAll().Where(x => x.Id == key).Any())
            {
                _repository.Remove(key);
                return new OperationResult();

            }
            return new OperationResult
            {
                Messages = new List<string>
                {
                  "This entity doesn't exist."
                }
            };
        }

        public IOperationResult UpdateEmployeeTask(EmployeeTaskDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                return new OperationResult
                {
                    Messages = result.Errors.Select(x => x.ErrorMessage)
                };
            }
            var entity = _repository.GetById(dto.Id);

            if (entity == null)
            {
                return
                    new OperationResult
                    {
                        Messages = new List<string>
                        {
                            "This entity is not found."
                        }
                    };
            }
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            return new OperationResult();
        }
    }
}
