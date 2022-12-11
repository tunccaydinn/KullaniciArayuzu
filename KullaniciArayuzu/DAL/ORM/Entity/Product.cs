﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciArayuzu.DAL.ORM.Entity
{
    public class Product:BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        [MaxLength(20)]
        public string QuantityUnit { get; set; }
    }
}
