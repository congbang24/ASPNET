using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day3_NguyenCongBang.Data;
using Day3_NguyenCongBang.Models;

namespace Day3_NguyenCongBang.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: ProductController
        public ActionResult Index([FromQuery] string? sortOrder, [FromQuery] int page = 1)
        {
            ViewBag.CurrentSort = sortOrder;
            // Xác định tham số đảo chiều khi click vào tiêu đề cột
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.CategorySortParm = sortOrder == "cate_asc" ? "cate_desc" : "cate_asc";

            var productQuery = SeedData.products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryName = SeedData.categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "Không xác định"
            });

            // Sắp xếp dữ liệu (Sorting)
            productQuery = sortOrder switch
            {
                "name_desc" => productQuery.OrderByDescending(p => p.Name),
                "price_asc" => productQuery.OrderBy(p => p.Price),
                "price_desc" => productQuery.OrderByDescending(p => p.Price),
                "cate_asc" => productQuery.OrderBy(p => p.CategoryName),
                "cate_desc" => productQuery.OrderByDescending(p => p.CategoryName),
                _ => productQuery.OrderBy(p => p.Id),
            };

            // Phân trang (Pagination)
            int pageSize = 3; // 3 sản phẩm mỗi trang
            var paginatedProducts = PaginatedList<ProductViewModel>.Create(productQuery, page, pageSize);

            return View(paginatedProducts);
        }

        // GET: ProductController/Details/5
        public ActionResult Details([FromRoute] int id)
        {
            _logger.LogInformation("Details action called for Product with id: {Id}", id);

            var product = SeedData.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                _logger.LogWarning("Product with id {Id} not found", id);
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = SeedData.categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Không xác định"
            };

            return View(viewModel);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(SeedData.categories, "Id", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                int maxId = SeedData.products.Any() ? SeedData.products.Max(p => p.Id) : 0;
                product.Id = maxId + 1;
                SeedData.products.Add(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(SeedData.categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var product = SeedData.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(SeedData.categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Product product)
        {
            var existingProduct = SeedData.products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(SeedData.categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete([FromRoute] int id)
        {
            var product = SeedData.products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = SeedData.categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Không xác định"
            };

            return View(viewModel);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var existingProduct = SeedData.products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            SeedData.products.Remove(existingProduct);
            return RedirectToAction(nameof(Index));
        }
    }
}

