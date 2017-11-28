using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PakClassified
{
   public class AdvertisementTypeHandler
    {
        public List<AdvertisementType> GetAdvertisementTypes()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from adtype in _context.Types
                        select adtype).ToList();
            }

        }
    }
}
