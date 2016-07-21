
namespace DataAccess.Repository
{
    using Entity;
    using System;
    using System.Linq;  
    using System.Data.Entity;
    using System.Linq.Expressions;

    public abstract class BaseRepository<T> where T : BaseEntity, new()
    {
        private readonly TaskManagerDb<T> Db;

        public BaseRepository()
        {
            this.Db = new TaskManagerDb<T>();
        }
        private void Insert(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            this.Db.SaveChanges();
        }

        private void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            this.Db.SaveChanges();
        }

        public T GetById(object id)
        {
            return this.Db.Items.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, Boolean>> expr = null, int page = 0, int pageSize = 0)
        {
            IQueryable<T> result = Db.Items;

            if (expr != null)
                result = result.Where(expr);

            if (page > 0 && pageSize > 0)
                result = result.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize);

            return result;
        }

        public int Count(Expression<Func<T, Boolean>> expr = null)
        {
            return expr == null ? this.Db.Items.Count() : this.Db.Items.Count(expr);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            this.Db.SaveChanges();
        }

        public void Save(T entity)
        {
            if (entity.Id > 0)
            {
                Update(entity);
            }
            else
            {
                Insert(entity);
            }
        }

        private void ChangeState(T entity, EntityState state)
        {
            var dbEntry = this.Db.Entry(entity);
            dbEntry.State = state;
        }
    }
}
