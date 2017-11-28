using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.UserMange
{
   public class UserHandler
    {
        public List<User> GetUseres()
        {
            using (DemoContaxt _context= new DemoContaxt())
            {
                return (from u in _context.Useres.Include("Role").Include("Address.City.Province.Country") select u).ToList();
            }
        }

        public User GetUser(string loginId,string password)
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from u in _context.Useres.Include("Role").Include("Address.City.Province.Country") where u.loginId == loginId && u.Password == password select u).FirstOrDefault();
            }
        }

        public List<Role> GetRoles()
        {
            using (DemoContaxt _context = new DemoContaxt())
            {
                return (from r in _context.Roles select r).ToList();
            }
        }
    }
}
