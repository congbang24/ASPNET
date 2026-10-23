using Microsoft.AspNetCore.Mvc;

namespace Day2_NguyenCongBang.Controllers
{
    /// <summary>
    /// DEMO YÊU CẦU 2: ATTRIBUTE ROUTING
    /// Tất cả route trong Controller này được cấu hình bằng các thuộc tính [Route] trực tiếp trên class và action,
    /// thay vì phụ thuộc vào MapControllerRoute trong Program.cs (Conventional Routing).
    /// </summary>
    [Route("dieu-huong-attribute")]
    public class RoutingDemoController : Controller
    {
        // Khớp URL: /dieu-huong-attribute hoặc /dieu-huong-attribute/tong-quan
        [HttpGet("")]
        [HttpGet("tong-quan")]
        public IActionResult Index()
        {
            return View();
        }

        // Khớp URL có tham số: /dieu-huong-attribute/sinh-vien/2026/Nguyen-Cong-Bang
        [HttpGet("sinh-vien/{id:int}/{ten}")]
        public IActionResult StudentDetail(int id, string ten)
        {
            ViewBag.Id = id;
            ViewBag.StudentName = ten;
            ViewBag.CurrentUrl = Request.Path;
            return View();
        }
    }
}
