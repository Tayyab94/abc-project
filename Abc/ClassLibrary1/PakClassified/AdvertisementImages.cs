using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassLibrary1.PakClassified
{
    public class AdvertisementImages
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(300)]

        public string Url { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Caption { get; set; }

        public int Priority { get; set; }
    }
}
