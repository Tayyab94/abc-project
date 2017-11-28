using Abc.Models;
using ClassLibrary1.PakClassified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(int id)
        {

            DDLViewModel model = new DDLViewModel();
            model.Name = "SubCatagory";
            model.Caption = "- Select SubCatagory -";
            model.Values = new CatagoriesHandler().GetSubCatagories(id).ToSelectList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", model);


            //return PartialView("~/Views/Test/Index.cshhtml");
        }
    }
}