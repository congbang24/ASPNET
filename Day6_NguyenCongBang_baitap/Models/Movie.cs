using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day6_NguyenCongBang_baitap.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề phim không được để trống")]
        [Display(Name = "Title")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày phát hành không được để trống")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Thời lượng phim không được để trống")]
        [Display(Name = "Duration")]
        [Range(1, 1000, ErrorMessage = "Thời lượng phim phải từ 1 đến 1000 phút")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        // Quan hệ: Phim thuộc về 1 thể loại
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}
