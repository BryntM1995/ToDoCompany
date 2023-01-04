using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ToDoCompany.Model.Entities;
using ToDoCompany.Service.DTOs;

namespace ToDoCompany.Service.FluentValidation
{
    public class EmployeeValidation : AbstractValidator<EmployeeDto> , IBaseValidator
    {
        public EmployeeValidation()
        {
            RuleFor(dto => dto.Id).NotNull();
            RuleFor(dto => dto.EmployeeName).NotNull().Equal("Emmanuel");
            RuleFor(dto => dto.EmployeeAge).NotNull().GreaterThan(17);
            RuleFor(dto => dto.EmployeePhone).NotNull().CreditCard();
        }
    }
}
