using BookProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BookProject.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BookProject.DataAccess.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(BookDbContext db)
        {
            _db= db;
          //  _db.Books.Include(b => b.Category);
            this.dbSet=_db.Set<T>();
        }
        public void Add(T entity)
        {
            _db.Add(entity);
        }
        //include properties  for Category
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[]{ ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query =query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
