﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Marka")]
    public class Brand
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Marka Adı")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}