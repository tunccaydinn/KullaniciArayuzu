using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciArayuzu.DAL.ORM.Entity
{
    public class BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Column(Order =2)]
        public string Name { get; set; }
        [Column(TypeName ="datetime2")]
        public DateTime Added_Time { get; set; }
        public bool isActive { get; set; }
    }
}
