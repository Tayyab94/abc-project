using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class LocationHandler
    {
       public List<Country> GetCountries()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from c in _context.Countries select c).ToList();
            }
        }

        public List<Province> GetProvinces()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from pro in _context.Provinces select pro).ToList();
            }
        }

        public Country GetCountry(int id)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from c in _context.Countries where c.Id == id select c).FirstOrDefault();
            }
        }

        public List<Province> GetProvinces(Country country)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from p in _context.Provinces
                        .Include("Country")
                        where p.Country.Id == country.Id
                        select p).ToList();
            }
        }

        public List<City> GetCities(Province province)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from citi in _context.Cities
                        .Include("Province.Country")
                        where citi.Province.Id == province.Id
                        select citi).ToList();
            }
        }
    }
}
