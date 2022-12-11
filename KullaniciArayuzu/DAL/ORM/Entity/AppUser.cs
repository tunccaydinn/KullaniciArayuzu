using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciArayuzu.DAL.ORM.Entity
{
    [Table("Users")]
   public class AppUser:BaseEntity
    {
        [MaxLength(30)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName 
        {
            get
            {
                if (String.IsNullOrWhiteSpace(LastName))
                {
                    return Name;

                }
                else
                {
                    return Name + " " + LastName;

                }
            }
            
            }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }




    }
}
