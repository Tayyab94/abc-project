using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1.PakClassified;
using Abc.Models;

namespace Abc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
             ViewBag.NewAdvs = new AdvertisementsHandler().GetLatestAllAdvertisements(12).ToAdvSumModelList();
            //ViewBag.NewAdvs = new AdvertisementsHandler().GetAllAdvertisements().ToAdvSumModelList();
            return View();
        }

        [HttpGet]
        public ActionResult Admin()
        {
            ViewBag.NewAdvs = new AdvertisementsHandler().GetLatestAllAdvertisements(12).ToAdvSumModelList();
            return View();
        }
    }
}