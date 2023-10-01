using BusinessLayer.Repositories;
using DAL.Entities;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }



        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var values = _productRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public string AddProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                return product.ProductName + " isimli ürün başarılı bir şekilde eklendi.";
            }
            catch (Exception exception) 
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpDelete("{id}")]
        public string DeleteProduct(int id)
        {
            try
            {
                var values = _productRepository.GetByID(id);
                _productRepository.Delete(values);

                return id + "li ürün başarılı bir şekilde silindi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpPut]
        public string UpdateProduct(Product product)
        {
            try
            {
                _productRepository.Update(product);
                return product.ProductName + "isimli ürün başarılı bir şekilde güncellendi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

    }
}
