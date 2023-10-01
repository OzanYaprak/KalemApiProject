using BusinessLayer.Repositories;
using DAL.Entities;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepository<Invoice> _invoiceRepository;

        public InvoiceController(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public IActionResult InvoiceList()
        {
            //yeni ekledim
            var invoiceWithLines = _invoiceRepository.GetAll().Include(x=>x.SalesInvoiceLines).ToList();

            //var values = _invoiceRepository.GetAll();
            return Ok(invoiceWithLines);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var values = _invoiceRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public string AddInvoice(Invoice invoice)
        {
            try
            {
                _invoiceRepository.Add(invoice);
                return invoice.InvoiceDocNumber + " numaralı fatura başarılı bir şekilde eklendi.";
            }
            catch (Exception exception) 
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpDelete("{id}")]
        public string DeleteInvoice(int id)
        {
            try
            {
                var values = _invoiceRepository.GetByID(id);
                _invoiceRepository.Delete(values);

                return id + "li fatura başarılı bir şekilde silindi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpPut]
        public string UpdateInvoice(Invoice invoice)
        {
            try
            {
                _invoiceRepository.Update(invoice);
                return invoice.InvoiceDocNumber + "numaralı fatura başarılı bir şekilde güncellendi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

    }
}
