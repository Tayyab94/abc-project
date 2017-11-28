using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClassLibrary1.UserMange;

namespace ClassLibrary1.PakClassified
{
    public class Advertisement
    {
        public Advertisement()
        {
            Images = new List<AdvertisementImages>();
        }
        public int  Id { get; set; }

        [Required(ErrorMessage ="Please Enter the Title")]
        [Column(TypeName ="varchar")]
        [MaxLength(300)]
        public string  Title { get; set; }

        [Column(TypeName ="varchar")]
        public string Description { get; set; }

        public float Price { get; set; }

        public DateTime PostOn { get; set; }

        public DateTime ValidUpTo { get;set;}

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual City City { get; set; }

        [Required]
        public virtual SubCatagory SubCatagory { get; set; }

        [Required]

        public virtual AdvertisementType Type { get; set; }

        [Required]
        public virtual AdvertisementStatus Status { get; set; }

        public ICollection<AdvertisementImages> Images { get; set; }

    }
}
