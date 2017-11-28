using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.PakClassified
{
    public class AdvertisementsHandler
    {

        public List<Advertisement> GetAllAdvertisements()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from adv in _context.Advertisements
                        .Include(a => a.SubCatagory.Catagory)
                        .Include(a => a.City.Province.Country)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                        .Include(a => a.Status)
                        .Include(a => a.Type)
                        select adv).ToList();
            }
        }


     
        public List<Advertisement> GetLatestAllAdvertisements(int count)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from adv in _context.Advertisements
                        .Include(a => a.SubCatagory.Catagory)
                        .Include(a => a.City.Province.Country)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                        .Include(a => a.Status)
                        .Include(a => a.Type)
                        select adv).Take(count).ToList();
            }
        }

        public List<Advertisement> GetAllAdvertisementsByCatagory(Catagory catagory)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from adv in _context.Advertisements
                        .Include(a => a.SubCatagory.Catagory)
                        .Include(a => a.City.Province.Country)
                        .Include(a => a.User)
                        .Include(a => a.Images)
                        .Include(a => a.Status)
                        .Include(a => a.Type)
                        where adv.SubCatagory.Catagory.Id == catagory.Id
                        select adv).ToList();
            }
        }

        public void Addd(Advertisement advertisementObj)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                _context.Entry(advertisementObj.City).State = EntityState.Unchanged;
                _context.Entry(advertisementObj.Type).State = EntityState.Unchanged;
                _context.Entry(advertisementObj.SubCatagory).State = EntityState.Unchanged;
                _context.Entry(advertisementObj.Status).State = EntityState.Unchanged;
                _context.Entry(advertisementObj.User).State = EntityState.Unchanged;

                _context.Advertisements.Add(advertisementObj);
                _context.SaveChanges();
            }
        }


        public Advertisement GetAllAdvertisementsById(int id)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from adv in _context.Advertisements

                        .Include(a => a.Images)
                        where adv.Id == id
                        select adv).FirstOrDefault();
            }
        }


        //Remove the Images 
        public void Delete(Advertisement adv)
        {
            using (DemoContaxt con = new DemoContaxt())
            {
                Advertisement delete = (from c in con.Advertisements
                                        .Include(a => a.Images)
                                        where c.Id == adv.Id
                                        select c).FirstOrDefault();
                con.Advertisements.Remove(delete);
                con.SaveChanges();
            }
        }

    }
}
