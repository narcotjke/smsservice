using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GenericRepository<T>:IRepository<T> where T:class
    {
        private readonly SmsServiceContext _context;
        private  readonly DbSet<T> _dbSet;

        public GenericRepository(SmsServiceContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
        }

        public virtual void Update(T item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(T item)
        {
            _dbSet.Remove(item);
        }
    }
}
