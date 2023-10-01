using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities;
using DAL.Entities;

namespace ApiProjectUI.ViewModels
{
    public class AdminViewModel
    {
        public int AdminID { get; set; }

        [Display(Name = "Admin Adı")]
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "Maks. 30 karakter girişi yapınız")]
        public string Name { get; set; }

        [Display(Name = "Admin Soyadı")]
        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "Maks. 30 karakter girişi yapınız")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        [StringLength(20, ErrorMessage = "Maks. 20 karakter girişi yapınız")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Column(TypeName = "varchar(32)")]
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        [StringLength(32, ErrorMessage = "Maks. 32 karakter girişi yapınız")]
        public string Password { get; set; }

        [Display(Name = "Son Giriş Yaptığı Tarih / Saat")]
        public DateTime LastLoginDate { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Son Giriş Yaptığı IP NO")]
        public string LastLoginIPNo { get; set; }
    }
}
