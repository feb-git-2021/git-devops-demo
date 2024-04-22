using BookProject.DataAccess.Data;
using BookProject.DataAccess.Repository.IRepository;
using BookProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.DataAccess.Repository
{
    public class BookRepository:Repository<Book>, IBookRepository
    {
        private readonly BookDbContext _db;
        public BookRepository(BookDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Book obj)
        {
           // _db.Update(obj);
           //better way

            var objFromDb = _db.Books.FirstOrDefault(x => x.Id == obj.Id);
            if(objFromDb == null)
            {
                objFromDb.BookTitle = obj.BookTitle;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
