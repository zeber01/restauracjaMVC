using JOTB_Restauracja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JOTB_Restauracja.Cotext
{
    public class RestauracjaContext : IdentityDbContext<ApplicationUser>
    {
        public RestauracjaContext() : base("DefaultConnection")
        {

        }

        public DbSet<DaniaModel> Dania { get; set; }
        public DbSet<DaniaProduktyModel> DaniaProdukty { get; set; }
        public DbSet<PracownikModel> Pracownicy { get; set; }
        public DbSet<ProduktyModel> Produkty { get; set; }
        public DbSet<ZamowienieModel> Zamowienia { get; set; }
        public DbSet<ZamowienieDanieModel> ZamowieniaDania { get; set; }

    }
}