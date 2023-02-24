using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Data
{
    public class BookDBContext:DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options):base(options) { }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Book> books { get; set; }
        public virtual DbSet<Publisher> publishers { get; set; }
        public virtual DbSet<Author> authors { get; set;}
        public DbSet<QuanLyThuVien.Models.usersaccounts> usersaccounts { get; set; }
        public DbSet<QuanLyThuVien.Models.orders> orders { get; set; }
        public DbSet<QuanLyThuVien.Models.report> report { get; set; }
    }
}
