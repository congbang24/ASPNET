using Day3_NguyenCongBang.Models;

namespace Day3_NguyenCongBang.Data
{
    public class SeedData
    {
        // Giả lập dữ liệu ban đầu cho database
        public static List<Category> categories = new List<Category>
        {
            new Category() { Id = 1, Name = "Category 1", Description = "Description 1" },
            new Category() { Id = 2, Name = "Category 2", Description = "Description 2" },
            new Category() { Id = 3, Name = "Category 3", Description = "Description 3" },
        };
    }
}
