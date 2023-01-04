using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoCompany.Model.Entities;
using ToDoCompany.Service.DTOs;

namespace ToDoCompany.Service.FluentValidation
{
    public class EmployeeTaskValidation : AbstractValidator<EmployeeTaskDto> , IBaseValidator
    {
        public EmployeeTaskValidation()
        {
            RuleFor(employeetask => employeetask.Id).NotNull();
            RuleFor(employeetask => employeetask.EmployeeIdInTask).NotNull().WithMessage("Please enter  a valid value.");
            RuleFor(employeetask => employeetask.TaskDescription).NotNull();
            RuleFor(employeetask => employeetask.TaskName).NotNull();
        }
    }
}
