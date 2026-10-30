using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_NguyenCongBang.Data; 

namespace Day3_NguyenCongBang.Controllers
{
    public class CategoryController : Controller
    {
        
        public ActionResult Index()
        {
            var _cate = SeedData.categories; 
            return View(_cate);              
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            //lay ra category co id truyen vao tu SeedData
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            //neu category==null thi tra ve trang loi
            if (category == null)
            {
                return NotFound();
            }
            //neu category khac null thi tra ve view va truyen category vao view

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Category category) 
        {
            if (ModelState.IsValid) 
            {
                //
                int maxId = SeedData.categories.Max(c => c.Id);
                //
                category.Id = maxId + 1;
                SeedData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        // GET: CategoryController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            // Sửa thành == để so sánh
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);

            // Nếu không tìm thấy thì trả về NotFound (mã lỗi 404)
            if (category == null)
            {
                return NotFound();
            }

            // Tìm thấy thì trả về View và truyền đối tượng vào View để chỉnh sửa
            return View(category);
        }


        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Category category)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([FromRoute] int id)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            SeedData.categories.Remove(existingCategory);
            return RedirectToAction(nameof(Index));
        }
    }
}
