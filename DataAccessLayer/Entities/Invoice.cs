using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Fatura")]
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Display(Name = "Belge Numarası")]
        [Required(ErrorMessage = "Belge Numarası girilmelidir")]
        [MaxLength(9)]
        public string InvoiceDocNumber { get; set; }

        [Display(Name = "Belge Tarihi")]
        [Required(ErrorMessage = "Belge Tarihi girilmelidir")]
        public DateTime InvoiceDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; }
    }
}