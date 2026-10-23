using Microsoft.AspNetCore.Mvc;

namespace Day2_NguyenCongBang.ViewComponents
{
    public class CourseSummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title = "Danh sách học phần nổi bật")
        {
            // Logic xử lý C# độc lập trong ViewComponent:
            var courses = new List<string>
            {
                "C# căn bản và nâng cao",
                "ASP.NET Core MVC (Controllers, Views, Routing)",
                "Entity Framework Core & SQL Server",
                "Xây dựng RESTful Web API"
            };

            ViewBag.ComponentTitle = title;
            ViewBag.ServerTime = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

            return View(courses);
        }
    }
}
