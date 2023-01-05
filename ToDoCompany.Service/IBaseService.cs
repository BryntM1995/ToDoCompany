using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections.Generic;
using System.Linq;
using ToDoCompany.Core;
using ToDoCompany.Model.Entities;
using ToDoCompany.Repository;
using ToDoCompany.Service.DTOs;

namespace ToDoCompany.Service
{
    public interface IBaseService<Entity>
    {
        IOperationResult Add(Entity entity);
        IOperationResult Update(Entity entity);
        IOperationResult Remove(int key);
        Entity GetById(int key);
        IEnumerable<Entity> GetAll();
    }
    public class BaseService<Entity, EntityDto> : IBaseService<EntityDto>
        where EntityDto : class, IBaseDto
        where Entity : class, IBaseEntity
    {
        private readonly IValidator<EntityDto> _validator;
        private readonly IMapper _mapper;
        protected readonly IBaseRepository<Entity> _repository;
        public BaseService(
            IBaseRepository<Entity> repository,
            IMapper mapper,
            IValidator<EntityDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public IOperationResult Add(EntityDto dto)
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
            var entity = _mapper.Map<Entity>(dto);
            _repository.Add(entity);
            return new OperationResult();
        }

        public IEnumerable<EntityDto> GetAll()
        {
            var entitydtos = _mapper.Map<IEnumerable<EntityDto>>(_repository.GetAll());
            return entitydtos;
        }

        public EntityDto GetById(int key)
        {
            var entity = _repository.GetById(key);
            var dto = _mapper.Map<EntityDto>(entity);
            return dto;
        }

        public IOperationResult Remove(int key)
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

        public IOperationResult Update(EntityDto dto)
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
