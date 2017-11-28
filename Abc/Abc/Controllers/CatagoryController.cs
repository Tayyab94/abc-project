using ClassLibrary1.PakClassified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
namespace Abc.Controllers
{
    public class CatagoryController : Controller
    {
        private DemoContaxt _context = new DemoContaxt();
        // GET: Catagory
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            Catagory obj = new Catagory();
            obj.Name = data["cName"];
            _context.Catagories.Add(obj);
            _context.SaveChanges();
            return RedirectToAction ("Index", "Catagory");
        }

        [HttpGet]
        public ActionResult ShowCatagory()
        {
           List<Catagory>c= _context.Catagories.ToList();
            return View(c);
        }
    }
}