using AutoMapper;
using FluentValidation;
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
        IQueryable<Entity> GetAll();
    }
    public class BaseService<Entity, EntityDto> : IBaseService<EntityDto>
        where EntityDto : class, IBaseDto
        where Entity : class, IBaseEntity
    {
        private readonly AbstractValidator<EntityDto> _validator;
        private readonly IMapper _mapper;
        protected readonly IBaseRepository<Entity> _repository;
        public BaseService(
            IBaseRepository<Entity> repository,
            IMapper mapper,
            AbstractValidator<EntityDto> validator)
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
                    Messages = result.Errors.Select(x => x.ErrorMessage).ToList(),
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

        public IQueryable<EntityDto> GetAll()
        {
            var Entitydtos = _mapper.Map<IQueryable<EntityDto>>(_repository.GetAll());
            return Entitydtos;
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
            var entity = _repository.GetById(dto.Id);
            if (entity == null & !result.IsValid & !_repository.GetAll().Where(x => x.Id == dto.Id).Any())
            {
                return
                    new OperationResult
                    {
                        Messages = new List<string>
                        {
                            "This entity wasn't updated."
                        }
                    };
            }
            _repository.Update(entity);
            return new OperationResult();
        }
    }
}
