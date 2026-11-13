using System.ComponentModel.DataAnnotations;

namespace Day3_NguyenCongBang.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Giá")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public decimal Price { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Danh mục")]
        public string CategoryName { get; set; } = string.Empty;
    }
}

