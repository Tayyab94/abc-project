using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using ClassLibrary1.PakClassified;

namespace Abc.Models
{
    public static class ModelHelper
    {
        public static List<SelectListItem> ToSelectList(this IEnumerable<IListable> values)
        {
            List<SelectListItem> tempList = new List<SelectListItem>();
            foreach (var v in values)
            {
                tempList.Add(new SelectListItem { Text = v.Name, Value = Convert.ToString(v.Id) });
            }
            tempList.TrimExcess();
            return tempList;    
        }

        public static List<AdvertisementSumModel> ToAdvSumModelList(this List<Advertisement> advertisement)
        {
            List<AdvertisementSumModel> tempList = new List<AdvertisementSumModel>();
            foreach (var adv in advertisement)
            {
                AdvertisementSumModel m = new AdvertisementSumModel();
                m.Id = adv.Id;
                m.Title = adv.Title;
                m.Price = adv.Price;
                m.ImageUrl = (adv.Images.Count > 0) ? adv.Images.First().Url : "/images/temp/nophoto.png";
                tempList.Add(m);
            }
            tempList.TrimExcess();
            return tempList;
        }


    }
}