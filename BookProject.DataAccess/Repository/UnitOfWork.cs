using BookProject.DataAccess.Data;
using BookProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookDbContext _db;
        public UnitOfWork(BookDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Book= new BookRepository(_db);
        }
        public ICategoryRepository Category { get;private set; }
        public IBookRepository Book { get; private set; }



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
