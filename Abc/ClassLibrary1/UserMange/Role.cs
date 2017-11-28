using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.UserMange
{
   public class Role
    {
        public int Id { get; set; }

        private string name;
        [Required]
        [MaxLength(50)]
        [Column(TypeName ="varchar")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
