using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(20)]
        public string? AuthorName { get; set; }
        [Required]
        [StringLength(50)]
        public string? Address { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        public string? History { get; set; }
        public string? Sex { get; set; }
        [Required]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
