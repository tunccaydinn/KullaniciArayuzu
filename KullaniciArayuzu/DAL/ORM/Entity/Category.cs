using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciArayuzu.DAL.ORM.Entity
{
    public class Category:BaseEntity
    {
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
