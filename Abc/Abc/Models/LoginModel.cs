using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Models
{
    public class LoginModel
    {
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",ErrorMessage ="Invalid Message")]
        [StringLength(25,MinimumLength =7,ErrorMessage ="Min 7 or  Maximum 25 characotrs")]
        [Display(Name ="Login Id")]
        public string LoginId { get; set; }

        [StringLength(25,MinimumLength =25,ErrorMessage ="Min 7 AMximum 25")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}