using QuanLyThuVien.Method;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien.Models
{
    public class Book:PostPrototype
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(100)]
        public string? BookName { get; set; }
        [DataType(DataType.Currency)]
        public double? Prices { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        public string? Description { get; set; }
        public string? Picture { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateUpdate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public int Viewed { get; set; } = 0;
        public int Saled { get; set; } = 0;
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }

        public PostPrototype Clone()
        {
            Book newBook = new Book();
            newBook.BookName= BookName;
            newBook.Prices = Prices;
            newBook.Description = Description;
            newBook.Picture = Picture;
            newBook.DateUpdate = DateUpdate;
            newBook.Quantity = Quantity;
            newBook.PublisherId = PublisherId;
            newBook.CategoryId = CategoryId;
            newBook.AuthorId = AuthorId;
            newBook.Viewed = Viewed;
            newBook.Saled = Saled;
            return newBook;
        }
    }
}
