using System.ComponentModel.DataAnnotations;

namespace ApiProjectUI.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }

        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "Müşteri adı girilmelidir")]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Display(Name = "Müşteri Soyadı")]
        [Required(ErrorMessage = "Müşteri soyadı girilmelidir")]
        [MaxLength(50)]
        public string CustomerSurname { get; set; }

        [Display(Name = "Müşteri TCKN")]
        [Required(ErrorMessage = "Müşteri TCKN girilmelidir")]
        [MaxLength(11)]
        public string CustomerTcID { get; set; }

        [Display(Name = "Müşteri Doğum Tarihi")]
        [Required(ErrorMessage = "Müşteri doğum tarihi girilmelidir")]
        public DateTime CustomerBirthDate { get; set; }

        [Display(Name = "Müşteri Durumu")]
        [Required(ErrorMessage = "Müşteri Aktif/Pasif belirtilmelidir")]
        public bool CustomerStatus { get; set; }
    }
}
