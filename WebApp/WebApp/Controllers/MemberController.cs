using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        private WebAppEntities db= new WebAppEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberModel model)

        {

            using (var context = new WebAppEntities())
            {
                bool isAuthentic = context.MaemberTab.Any(x =>x.Username == model.Username && x.Password == model.Username);
                if (isAuthentic)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("GetAll", "Employee");
                }
                ModelState.AddModelError("", "Invalid Credentials");

                return RedirectToAction("Login");
            }

        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(MaemberTab model)
        {
            using (var context = new WebAppEntities())
            {
                context.MaemberTab.Add(model);
                context.SaveChanges();
                //ViewBag.msg = "Seccess";
;            }

            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}