using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.Models;
using ClassLibrary1.UserMange;

namespace Abc.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.ReturnUrl = Request.QueryString["returnurl"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel obj)
        {
            User user = new UserHandler().GetUser(obj.LoginId, obj.Password);
            if(user!=null)
            {
                Session.Add(WebUtil.CURRENT_USER, user);
                string temp = Request.QueryString["returnurl"];
                string[] parts = temp.Split('/');

                if(user.IsRole(WebUtil.ADMIN_ROLE))
                {
                    if (!string.IsNullOrWhiteSpace(temp)) return RedirectToAction(parts[1], parts[0]);
                    return RedirectToAction("Admin", "Home");
                }
                if (!string.IsNullOrWhiteSpace(temp)) return RedirectToAction(parts[1], parts[0]);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            return View();
        }

        /* implementation  of following methods is left for students as assignment */

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RecoverPassword()
        {
            return View();
        }
    }
}