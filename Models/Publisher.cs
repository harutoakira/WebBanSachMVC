using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVien.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        [Required]
        [StringLength(50)]
        public string? PublisherName { get; set; }
        [Required]
        [StringLength(50)]
        public string? Address { get; set; }
        [Required]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

    }
}
