using System.ComponentModel.DataAnnotations;

namespace Day6_NguyenCongBang_baitap.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [Display(Name = "Thể loại")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Quan hệ 1 - N: Một thể loại có nhiều phim
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
