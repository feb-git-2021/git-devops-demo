using Microsoft.EntityFrameworkCore;

using BookProject.Models.Models;

namespace BookProject.DataAccess.Data
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
