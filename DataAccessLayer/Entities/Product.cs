using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Ürün")]
    public class Product
    {
        [Key]
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