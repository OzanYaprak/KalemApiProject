using BusinessLayer.Repositories;
using DAL.Entities;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }



        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _customerRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var values = _customerRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public string AddCustomer(Customer customer)
        {
            try
            {
                _customerRepository.Add(customer);
                return customer.CustomerName + " isimli müşteri başarılı bir şekilde eklendi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpDelete("{id}")]
        public string DeleteCustomer(int id)
        {
            try
            {
                var values = _customerRepository.GetByID(id);
                _customerRepository.Delete(values);

                return id + "li müşteri başarılı bir şekilde silindi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpPut]
        public string UpdateCustomer(Customer customer)
        {
            try
            {
                _customerRepository.Update(customer);
                return customer.CustomerName + "isimli müşteri başarılı bir şekilde güncellendi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

    }
}
