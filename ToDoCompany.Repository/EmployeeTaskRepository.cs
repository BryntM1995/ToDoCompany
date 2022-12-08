using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Repository
{
    internal class EmployeeTaskRepository: IRepository<EmployeeTask>
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<EmployeeTask> _dbSet;
        public EmployeeTaskRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<EmployeeTask>();
        }

        public void Add(EmployeeTask entity)
        {
            _dbSet.Add(entity);
            Commit();
        }

        public void Update(EmployeeTask entity)
        {
            Update(entity);
        }

        public bool Remove(int key)
        {
            var item = GetById(key);
            item.IsDeleted = true;
            Update(item);
            Commit();
            return true;
        }

        public EmployeeTask GetById(int key)
        {
            return GetAll().Where(x => x.EmployeeID == key).FirstOrDefault();
        }

        public IQueryable<EmployeeTask> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted == false);
        }

        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }
    }
}
