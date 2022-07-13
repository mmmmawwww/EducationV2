using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.EF;
using Training.DAL.Interfaces;

namespace Training.DAL.Repositories
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected TrainingContext _context;
        protected DbSet<T> _dbSet;

        public EFGenericRepository(TrainingContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T item = _dbSet.Find(id);
            if (item != null)
                _dbSet.Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return  _dbSet.Where(predicate).ToList();
            
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
           
        }
    }
}
