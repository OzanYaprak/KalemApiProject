using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiProjectUI.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Ürün Adı Girilmelidir")]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün Markası Girilmelidir")]
        [MaxLength(100)]
        public string ProductBrand { get; set; }

        [Required(ErrorMessage = "Ürün SKT Girilmelidir")]
        public DateTime ProductExpDate { get; set; }

        [Required(ErrorMessage = "Ürün Aktif/Pasif belirtilmelidir")]
        public bool ProductStatus { get; set; }

        [Display(Name = "Marka")]
        public int? BrandID { get; set; }
        public Brand Brand { get; set; }
    }
}
