using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PakClassified
{
   public class CatagoriesHandler
    {
        public List<Catagory> GetCatagories()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from ct in _context.Catagories select ct).ToList();
            }
        }
        public List<SubCatagory> GetSubCatagories(int id)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from sct in _context.SubCatagories
                        .Include("Catagory")
                        where sct.Catagory.Id == id
                        select sct).ToList();
            }
        }

        public List<SubCatagory> GeSubtCatagorie()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from ct in _context.SubCatagories select ct).ToList();
            }
        }
    }
}
