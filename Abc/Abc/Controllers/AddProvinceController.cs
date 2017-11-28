using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using Abc.Models;

namespace Abc.Controllers
{
    public class AddProvinceController : Controller
    {
        private DemoContaxt _context = new DemoContaxt();
        // GET: AddProvince
        public ActionResult Index()
        {
            ViewBag.Countries = new LocationHandler().GetCountries().ToSelectList();
            return View();
        }
         [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            Province province = new Province();
            province.Name = data["ProvinceName"];
            province.Country = new Country { Id =Convert.ToInt32(data["Country"])};
            _context.Entry(province.Country).State = System.Data.Entity.EntityState.Unchanged;
            _context.Provinces.Add(province);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}