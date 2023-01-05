using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoCompany.Core;
using ToDoCompany.Model;
using ToDoCompany.Model.Context;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Repository
{   
    public interface IEmployeeRepository : IBaseRepository<Employee> { }
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
       
        public EmployeeRepository(CompanyDbContext dbContext) : base(dbContext)
        {
           
        }
    } 
}
