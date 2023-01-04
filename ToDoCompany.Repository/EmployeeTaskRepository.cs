using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Repository
{
    public interface IEmployeeTaskRepository : IBaseRepository<EmployeeTask> { }
    public class EmployeeTaskRepository: BaseRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
