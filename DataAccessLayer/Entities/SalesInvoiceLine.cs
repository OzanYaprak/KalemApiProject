using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("FaturaSatır")]
    public class SalesInvoiceLine
    {
        [Key]
        public int SalesInvoiceLineID { get; set; }

        [Required(ErrorMessage = "Fatura Satır No. Belirtilmelidir")]
        public int SalesInvoiceLineNumber { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Miktar Belirtilmelidir")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Birim Fiyat Belirtilmelidir")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}