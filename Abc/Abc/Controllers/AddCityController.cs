using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.Models;
using ClassLibrary1;

namespace Abc.Controllers
{
    public class AddCityController : Controller
    {
        private DemoContaxt _context = new DemoContaxt();
        // GET: AddCity
        public ActionResult Index()
        {
            ViewBag.citiList = new LocationHandler().GetProvinces().ToSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            City city = new City();
            city.Name = data["cityName"];
            city.Province = new Province { Id = Convert.ToInt32(data["ProvinceList"]) };
            _context.Entry(city.Province).State = System.Data.Entity.EntityState.Unchanged;
            _context.Cities.Add(city);
            _context.SaveChanges();
            return RedirectToAction("Index", "AddCity");
        }
    }
}