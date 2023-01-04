using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ToDoCompany.Core;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Repository
{
    public interface IBaseRepository<Entity>
    {
        void Add(Entity entity);
        void Update(Entity entity);
        bool Remove(int key);
        Entity GetById(int key);
        IQueryable<Entity> GetAll();
        public bool Commit();
    }
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class, IBaseEntity
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<Entity> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Entity>();
        }
        public void Add(Entity entity)
        {
            _dbSet.Add(entity);
            Commit();
        }

        public void Update(Entity entity)
        {
            Update(entity);
        }

        public bool Remove(int key)
        {
            var item = GetById(key);
            item.IsDeleted = true;
            Update(item);
            return Commit();
        }

        public Entity GetById(int key)
        {
            return GetAll().Where(x => x.Id == key).FirstOrDefault();
        }

        public IQueryable<Entity> GetAll()
        {
            return _dbSet;
        }

        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }
    }
}
