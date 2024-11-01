using _Nexus.Database;
using _Nexus.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace _Nexus.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NXContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(NXContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _context.Add(entity);

            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}