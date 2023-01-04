using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoCompany.Model.Entities;
using ToDoCompany.Service.DTOs;

namespace ToDoCompany.Service.Mapper
{
    public class EmployeeTaskProfile : Profile
    {
        public EmployeeTaskProfile()
        {
            CreateMap<EmployeeTaskDto, EmployeeTask>();
            CreateMap<EmployeeTask, EmployeeTaskDto>();
        }
    }
}
