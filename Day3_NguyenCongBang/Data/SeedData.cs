using Day3_NguyenCongBang.Models;

namespace Day3_NguyenCongBang.Data
{
    public class SeedData
    {
        // Giả lập dữ liệu ban đầu cho database
        public static List<Category> categories = new List<Category>
        {
            new Category() { Id = 1, Name = "Điện thoại", Description = "Các dòng điện thoại thông minh" },
            new Category() { Id = 2, Name = "Laptop", Description = "Máy tính xách tay" },
            new Category() { Id = 3, Name = "Phụ kiện", Description = "Phụ kiện công nghệ" },
        };

        public static List<Product> products = new List<Product>
        {
            new Product() { Id = 1, Name = "iPhone 15 Pro", Price = 25000000, Description = "Điện thoại flagship của Apple với chip A17 Pro", CategoryId = 1 },
            new Product() { Id = 2, Name = "Samsung Galaxy S24", Price = 22000000, Description = "Điện thoại tích hợp Galaxy AI tiên tiến", CategoryId = 1 },
            new Product() { Id = 3, Name = "Xiaomi 14", Price = 18000000, Description = "Ống kính Leica chuyên nghiệp, chip Snapdragon 8 Gen 3", CategoryId = 1 },
            new Product() { Id = 4, Name = "Google Pixel 8", Price = 16500000, Description = "Trải nghiệm Android thuần mượt mà, camera ấn tượng", CategoryId = 1 },
            new Product() { Id = 5, Name = "MacBook Air M2", Price = 24000000, Description = "Laptop mỏng nhẹ, pin trâu đến từ Apple", CategoryId = 2 },
            new Product() { Id = 6, Name = "Dell XPS 13", Price = 28000000, Description = "Laptop doanh nhân cao cấp màn hình viền siêu mỏng", CategoryId = 2 },
            new Product() { Id = 7, Name = "Asus Zenbook 14", Price = 20500000, Description = "Laptop văn phòng thanh lịch màn hình OLED", CategoryId = 2 },
            new Product() { Id = 8, Name = "Lenovo ThinkPad T14", Price = 26000000, Description = "Dòng máy trạm di động bền bỉ, bàn phím gõ êm", CategoryId = 2 },
            new Product() { Id = 9, Name = "Chuột Logitech MX Master 3S", Price = 2100000, Description = "Chuột công thái học cao cấp dành cho dân văn phòng", CategoryId = 3 },
            new Product() { Id = 10, Name = "Bàn phím cơ Keychron K2", Price = 1850000, Description = "Bàn phím cơ không dây kết nối đa thiết bị", CategoryId = 3 },
            new Product() { Id = 11, Name = "Tai nghe Sony WH-1000XM5", Price = 7500000, Description = "Tai nghe chống ồn chủ động hàng đầu thế giới", CategoryId = 3 },
            new Product() { Id = 12, Name = "Sạc dự phòng Anker 20000mAh", Price = 950000, Description = "Dung lượng lớn, sạc nhanh công suất cao", CategoryId = 3 },
        };
    }
}
