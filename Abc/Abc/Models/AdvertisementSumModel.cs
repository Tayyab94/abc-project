using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.Models
{
    public class AdvertisementSumModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public float Price { get; set; }
        public string ImageUrl { get; set; }
    }
}