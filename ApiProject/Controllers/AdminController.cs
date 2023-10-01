using BusinessLayer.Repositories;
using DAL.Entities;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository<Admin> _adminRepository;

        public AdminController(IRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }



        [HttpGet]
        public IActionResult AdminList()
        {
            var values = _adminRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdmin(int id)
        {
            var values = _adminRepository.GetByID(id);
            return Ok(values);
        }

        [HttpPost]
        public string AddAdmin(Admin admin)
        {
            try
            {
                _adminRepository.Add(admin);
                return admin.Name + " isimli admin başarılı bir şekilde eklendi.";
            }
            catch (Exception exception)
            {

                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpDelete("{id}")]
        public string DeleteAdmin(int id)
        {
            try
            {
                var values = _adminRepository.GetByID(id);
                _adminRepository.Delete(values);

                return id + "li admin başarılı bir şekilde silindi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

        [HttpPut]
        public string UpdateAdmin(Admin admin)
        {
            try
            {
                _adminRepository.Update(admin);
                return admin.Name + "isimli admin başarılı bir şekilde silindi.";
            }
            catch (Exception exception)
            {
                return "Bir hata meydana geldi. Detay:" + exception.Message;
            }
        }

    }
}
