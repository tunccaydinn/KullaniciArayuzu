using KullaniciArayuzu.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciArayuzu.DAL.ORM.Context
{
   public class ProjeContext:DbContext
    {
        public ProjeContext()
        {
            Database.Connection.ConnectionString = @"Server=.;Database=KullaniciArayuzu;Trusted_Connection=True;";
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
