using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.UserMange
{
   public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string FullName { get; set; }


        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        public string loginId { get; set; }

        private string password;
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string SecurityQuestion { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string SecurityQAnswet { get; set; }

        private string contactNumber;
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public virtual Address Address { get; set; }
        public virtual  City City { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(250)]
        public string Email { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(260)]
        public string ImageURL { get; set; }

        public Nullable<DateTime> DOB { get; set; }

        public Nullable<bool> IsActive { get; set; }

        [Required]
        public virtual Role Role { get; set; }


        public bool IsRole(int id)
        {
            return Role != null && Role.Id == id;
        }
    }
}
