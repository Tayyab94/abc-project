﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1
{
    public class City:IListable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public virtual Province Province { get; set; }
    }
}
