# Bài Thực Hành ASP.NET Core MVC - Day 6: Entity Framework Core

- **Sinh viên:** Nguyễn Công Bằng
- **Học phần:** Phát triển ứng dụng Web với ASP.NET Core MVC
- **Repository:** https://github.com/congbang24/ASPNET
- **Nhánh (Branch):** `day6`

---

## 📌 Nội dung bài tập

Xây dựng ứng dụng ASP.NET Core MVC sử dụng **Entity Framework Core (Code-First)** với 2 lớp thực thể có mối quan hệ **1 - N**:

### 1. Thực thể `Genre` (Thể loại phim)
- `Id`: `int` (Khóa chính)
- `Name`: `string` (Tên thể loại, ví dụ: *Hành động*, *Hoạt hình*, *Kinh dị*, *Hài kịch*...)
- Quan hệ: `ICollection<Movie> Movies` (1 thể loại có nhiều phim).

### 2. Thực thể `Movie` (Phim)
- `Id`: `int` (Khóa chính)
- `Title`: `string` (Tiêu đề phim)
- `ReleaseDate`: `DateTime` (Ngày phát hành)
- `Duration`: `int` (Thời lượng phim tính bằng phút)
- `GenreId`: `int` (Khóa ngoại tham chiếu đến bảng Genre)
- `Genre`: Navigation property tham chiếu đến thể loại tương ứng.

---

## 🚀 Các chức năng đã triển khai

1. **Entity Framework Core & Migration:**
   - Chuỗi kết nối SQL Server LocalDB trong `appsettings.json`.
   - DbContext `Day6_NguyenCongBang_baitapContext`.
   - Migration `InitialCreate` tạo bảng `Genre` và `Movie`.
   - Tự động nạp dữ liệu mẫu (`DbInitializer`) giống hệt bài giảng trên lớp:
     - `1 | James Bond | 2026 | Hành động | 120`
     - `2 | Doraemon | 2000 | Hoạt hình | 90`

2. **Chức năng CRUD Phim (Movie):**
   - **Danh sách phim (`Movie/Index`):** Hiển thị dạng bảng gồm `Id`, `Title`, `Date`, `Genre`, `Duration`.
   - **Thêm mới (`Movie/Create`):** Form nhập liệu với Title, Date, Duration và ô chọn thể loại Dropdown (Select List).
   - **Chỉnh sửa (`Movie/Edit`):** Cập nhật thông tin phim và thể loại.
   - **Chi tiết (`Movie/Details`):** Xem thông tin chi tiết của phim.
   - **Xóa (`Movie/Delete`):** Xóa phim kèm xác nhận.

3. **Quản lý thể loại (`Genre/Index`, `Genre/Create`):**
   - Xem và thêm các thể loại phim mới vào cơ sở dữ liệu.

4. **Script SQL:**
   - File `database.sql` đính kèm sẵn trong thư mục dự án để chạy hoặc nộp bài trực tiếp.
