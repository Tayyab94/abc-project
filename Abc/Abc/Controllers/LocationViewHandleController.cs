using Abc.Models;
using ClassLibrary1;
using ClassLibrary1.PakClassified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.Controllers
{
    public class LocationViewHandleController : Controller
    {
        // GET: LocationViewHandle
        public ActionResult province(int id)
        {
            DDLViewModel model = new DDLViewModel();
            model.Name = "Province";
            model.Caption = "-Select Province";
            model.GlyphIcon = "glyphicon-map-marker";
            model.Values = new LocationHandler().GetProvinces(new Country { Id = id }).ToSelectList();

            return PartialView("~/Views/Shared/_DDLView.cshtml", model);
        }

        public ActionResult City(int id)
        {
            DDLViewModel model = new DDLViewModel();
            model.Name = "City";
            model.Caption = "-Select City";
            model.GlyphIcon = "glyphicon-map-marker";
            model.Values = new LocationHandler().GetCities(new Province { Id = id }).ToSelectList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", model);
        }
        [HttpGet]
        public ActionResult GetSubCatagory(int id)
        {
            DDLViewModel model = new DDLViewModel();
            model.Name = "SubCatagory";
            model.Caption = "- Select SubCatagory -";
            model.Values = new CatagoriesHandler().GetSubCatagories(id).ToSelectList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", model);
        }
    }
}