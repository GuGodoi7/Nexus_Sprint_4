using _Nexus.Database;
using _Nexus.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

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

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = GetById(id); 
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuário não encontrado."); 
            }
        }



        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null; 
            }

            try
            {
                return _dbSet.Find(ObjectId.Parse(id));
            }
            catch (FormatException)
            {
                throw new Exception("ID inválido.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar o usuário: " + ex.Message);
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
