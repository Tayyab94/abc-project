using Abc.Models;
using ClassLibrary1.PakClassified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
namespace Abc.Controllers
{
    public class SubCatagoryController : Controller
    {
        private DemoContaxt _context = new DemoContaxt();
        // GET: SubCatagory
        public ActionResult Index()
        {
            ViewBag.Catagory = new CatagoriesHandler().GetCatagories().ToSelectList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            SubCatagory sCatagoryObj = new SubCatagory();
            sCatagoryObj.Name = data["sbCName"];
            sCatagoryObj.Catagory = new Catagory { Id = Convert.ToInt32(data["CatagoryId"]) };

            ViewBag.Catagory = new CatagoriesHandler().GetCatagories().ToSelectList();
            return View();
        }
    }
}