using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1.PakClassified;
using Abc.Models;
using ClassLibrary1;
using ClassLibrary1.UserMange;
using System.Diagnostics;

namespace Abc.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement  hahahha
        public ActionResult Index()
        {
            ViewBag.Catagory = new CatagoriesHandler().GetCatagories().ToSelectList();
            return View();
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

        [HttpGet]
        public ActionResult PostAdvertisement()
        {
            User CurrentUser =(User)Session[WebUtil.CURRENT_USER];
            if (CurrentUser == null) return RedirectToAction("Login", "Users", new { returnurl = "Advertisement/PostAdvertisement" });
            ViewBag.Country = new LocationHandler().GetCountries().ToSelectList();
            ViewBag.Catagory = new CatagoriesHandler().GetCatagories().ToSelectList();
            var temp = new AdvertisementTypeHandler().GetAdvertisementTypes().ToSelectList();
            temp.First().Selected= true;
            ViewBag.AdvType = temp;
            return View();
        }

        [HttpPost]
        public ActionResult PostAdvertisement(FormCollection data)
        {
            User CurrentUser = (User)Session[WebUtil.CURRENT_USER];
            if (CurrentUser == null) return RedirectToAction("Login", "Users", new { returnurl = "Advertisement/PostAdvertisement" });


            try
            {
                Advertisement advertisement = new Advertisement();
                advertisement.City = new City { Id = Convert.ToInt32(data["City"]) };
                advertisement.Title = data["AdvTitle"];
                advertisement.Price = Convert.ToSingle(data["Price"]);
                advertisement.ValidUpTo = Convert.ToDateTime(data["Validity"]);
                advertisement.SubCatagory = new SubCatagory { Id = Convert.ToInt32(data["SubCatagory"]) };
                advertisement.Type = new AdvertisementType { Id = Convert.ToInt32(data["AdvType"]) };
                advertisement.Description = data["Description"];
                advertisement.Status = new AdvertisementStatus { Id = 1 };
                advertisement.User = CurrentUser;
                advertisement.PostOn = DateTime.Now;

                long uno = DateTime.Now.Ticks;

                int count = 0;

                //foreach (var uno1 in Request.Files)
                //{
                //    string fcName;
                //    HttpPostedFileBase file = Request.Files["uno1"];
                //    if (!string.IsNullOrWhiteSpace(file.FileName))
                //    {
                //        string url = "~/DataImages/" + $"{uno}_{++count}" + file.FileName.Substring(file.FileName.LastIndexOf("."));
                //        string Path = Request.MapPath(url);

                //        advertisement.Images.Add(new AdvertisementImages { Url = url, Priority = ++count });
                //        //advertisement.Images.Add(new AdvertisementImages { Url = url, Priority = count });
                //        file.SaveAs(Path);

                //    }
                //}

                foreach (string fcName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fcName];
                    if (!string.IsNullOrWhiteSpace(file.FileName))
                    {
                        string url = "/DataImages/Images/" + $"{uno}_{++count}" + file.FileName.Substring(file.FileName.LastIndexOf("."));
                        string Path = Request.MapPath(url);

                        advertisement.Images.Add(new AdvertisementImages { Url = url, Priority = count });
                        //advertisement.Images.Add(new AdvertisementImages { Url = url, Priority = count });

                        file.SaveAs(Path);

                    }
                }
                new AdvertisementsHandler().Addd(advertisement);

                // This will show that whether the advertisement is Added or not 
                TempData.Add("AlertMessage", new AlertModel("Advertisement Added Successfully", AlertType.Success));
                    
            }
            catch(Exception ex)  //This will throw  the exception
            {
                TempData.Add("AlertMessage", new AlertModel("Fail to add Advertisement", AlertType.Error));
                Trace.WriteLine(DateTime.Now.ToString("F") + "," + ex.Message);
                Trace.WriteLine(ex.StackTrace);
                Trace.WriteLine("----------------------------------");
                Trace.Flush();
            }
            

            return RedirectToAction("PostAdvertisement");
        }


        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
           
            DemoContaxt c = new DemoContaxt();
            var rem = c.Advertisements.Where(x => x.Id.Equals(id)).SingleOrDefault();
            c.Advertisements.Remove(rem);
            c.SaveChanges();
            return View();
        }
    }
}