# Bài Thực Hành ASP.NET Core MVC - Day 2

- **Sinh viên:** Nguyễn Công Bằng
- **Học phần:** Phát triển ứng dụng Web với ASP.NET Core MVC
- **Repository:** https://github.com/congbang24/ASPNET

---

## 📌 Các chức năng và Demo kiểm tra

### 1. Cơ bản: Controller & View
- **Trang chủ mặc định:**
  - URL: `/` hoặc `/Home/Index` (Controller: `HomeController`)
- **Trang Hello Index:**
  - URL: `/Hello` hoặc `/Hello/Index` (Controller: `HelloController`)
- **Trang Hello Welcome (Truyền tham số qua ViewData / ViewBag):**
  - URL: `/Hello/Welcome?name=Bang&numTimes=4`
  - Cơ chế: Nhận tham số từ Query string và lặp qua thẻ `<h1>` với `@ViewBag.Message`.

---

### 2. Yêu cầu 1: Partial View & ViewComponent
- **URL Demo:** `/Home/ComponentsDemo` (Có nút bấm trực tiếp trên thanh menu)
- **Partial View (`_StudentInfoPartial.cshtml`):**
  - Vị trí: `Views/Shared/_StudentInfoPartial.cshtml`
  - Nhận dữ liệu thụ động từ View cha truyền vào bằng thẻ `<partial name="_StudentInfoPartial" model="..." />`.
- **ViewComponent (`CourseSummary`):**
  - Class C#: `ViewComponents/CourseSummaryViewComponent.cs`
  - View hiển thị: `Views/Shared/Components/CourseSummary/Default.cshtml`
  - Hoạt động độc lập như một mini-controller, tự xử lý dữ liệu và render qua `@await Component.InvokeAsync("CourseSummary")`.

---

### 3. Yêu cầu 2: Conventional Routing vs Attribute Routing
- **URL Demo:** `/dieu-huong-attribute` (Có nút bấm trực tiếp trên thanh menu)
- **Conventional Routing (Theo quy ước):**
  - Khai báo tập trung trong `Program.cs`: `pattern: "{controller=Home}/{action=Index}/{id?}"`
  - Ví dụ: `/Home/Index`, `/Hello/Index`.
- **Attribute Routing (Theo thuộc tính):**
  - Khai báo trực tiếp trên Controller và Action trong `RoutingDemoController.cs` bằng `[Route("...")]`.
  - Ví dụ URL tùy biến:
    - `/dieu-huong-attribute`
    - `/dieu-huong-attribute/sinh-vien/2026/Nguyen-Cong-Bang`

---

## 📸 Hình ảnh giao diện chạy thực tế

*(Dán ảnh chụp màn hình giao diện kết quả vào đây)*
