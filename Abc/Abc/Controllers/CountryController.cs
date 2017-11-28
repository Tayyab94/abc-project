using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Abc.Controllers
{
    public class CountryController : Controller
    {
        private DemoContaxt _context = new DemoContaxt();
        // GET: Country

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCountry(FormCollection data)
        {
            Country country = new Country();
            country.Name = data["cName"];
            country.Code = Convert.ToInt32(data["cCode"]);
            _context.Countries.Add(country);
            _context.SaveChanges();
            return RedirectToAction("AddCountry");
        }
    }
}