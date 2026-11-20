using Day6_NguyenCongBang_baitap.Models;

public static class DbInitializer
{
    public static void Initialize(Day6_NguyenCongBang_baitapContext context)
    {
        // Kiểm tra xem đã có thể loại nào chưa
        if (context.Genre.Any())
        {
            return; // Đã có dữ liệu
        }

        var genres = new Genre[]
        {
            new Genre { Name = "Hành động" },
            new Genre { Name = "Hoạt hình" },
            new Genre { Name = "Kinh dị" },
            new Genre { Name = "Hài kịch" },
            new Genre { Name = "Khoa học viễn tưởng" }
        };

        context.Genre.AddRange(genres);
        context.SaveChanges();

        // Thêm dữ liệu mẫu cho Movie giống hệt trên bảng của cô giáo
        var hanhDongGenre = context.Genre.First(g => g.Name == "Hành động");
        var hoatHinhGenre = context.Genre.First(g => g.Name == "Hoạt hình");

        var movies = new Movie[]
        {
            new Movie
            {
                Title = "James Bond",
                ReleaseDate = new DateTime(2026, 1, 1),
                Duration = 120,
                GenreId = hanhDongGenre.Id
            },
            new Movie
            {
                Title = "Doraemon",
                ReleaseDate = new DateTime(2000, 1, 1),
                Duration = 90,
                GenreId = hoatHinhGenre.Id
            }
        };

        context.Movie.AddRange(movies);
        context.SaveChanges();
    }
}
