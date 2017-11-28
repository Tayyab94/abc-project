using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.Models;
using ClassLibrary1.PakClassified;

namespace Abc.Controllers
{
    public class CatagotyHandlerController : Controller
    {
        // GET: CatagotyHandler
        public ActionResult Index(int id)
        {
            DDLViewModel model = new DDLViewModel();
            model.Name = "Sub Catagory";
            model.Caption = "- Select SubCatagory -";
            model.GlyphIcon = "glyphicon-tags";
            model.Values = new CatagoriesHandler().GetSubCatagories(id).ToSelectList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", model);
        }
    }
}