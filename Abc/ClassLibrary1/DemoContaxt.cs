using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClassLibrary1.UserMange;
using ClassLibrary1.PakClassified;

namespace ClassLibrary1
{
    public class DemoContaxt :DbContext
    {
        public DemoContaxt():base("tayyab")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<User> Useres { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Catagory> Catagories { get; set; }

        public DbSet<SubCatagory> SubCatagories { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<AdvertisementType> Types { get; set; }
    }
}
